using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace DocumentWebApp.Controllers
{
    public class DocumentController : Controller
    {
        private const string DocumentFolder = "wwwroot/document/";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewDocument(int category, string documentName)
        {
            string filePath = $"{DocumentFolder}{category}_{documentName}.txt";
            if (System.IO.File.Exists(filePath))
            {
                string content = System.IO.File.ReadAllText(filePath);
                ViewBag.DocumentContent = content;
            }
            return View();
        }

        public IActionResult CreateDocument(int category, string documentName)
        {
            string filePath = $"{DocumentFolder}{category}_{documentName}.txt";
            return View();
        }

        [HttpPost]
        public IActionResult SaveDocument(int category, string documentName, string content)
        {
            string filePath = $"{DocumentFolder}{category}_{documentName}.txt";
            System.IO.File.WriteAllText(filePath, content);
            return RedirectToAction("Index");
        }
    }
}

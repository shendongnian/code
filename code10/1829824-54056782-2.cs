        public class publicController : Controller
        {
            public ActionResult pic(string id)
            {
                var fileName = id;
                if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0) return NotFound();
                string absolutePath = Path.GetFullPath(Path.Combine("c:/public_assets/photos/", fileName));
                if (!System.IO.File.Exists(absolutePath)) return NotFound();
                string fileExtension = Path.GetExtension(absolutePath).Replace(".", "").ToLower();
                if (fileExtension != "jpg") return NotFound();
                var fileBytes = System.IO.File.OpenRead(absolutePath);
                fileName = Path.GetFileName(absolutePath);
                return File(fileBytes, "image/" + fileExtension, fileName);
            }
        }

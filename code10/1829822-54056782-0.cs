    public class publicController : Controller
    {
         public FileResult pic(string id = "1.JPG")
        {
            var fileName = id;
            if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0) throw new Exception();
            string absolutePath = Path.GetFullPath(Path.Combine("c:/public_assets/photos/", fileName));
            if (!System.IO.File.Exists(absolutePath)) throw new Exception();
            byte[] fileBytes = System.IO.File.ReadAllBytes(absolutePath);
            string fileExtension = Path.GetExtension(absolutePath).Replace(".", "");
            fileName = Path.GetFileName(absolutePath);
            return File(fileBytes, "image/" + fileExtension, fileName);
        }
    }

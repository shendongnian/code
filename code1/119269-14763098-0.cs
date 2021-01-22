    public class MyBaseController : Controller
    {
        protected FileContentResult TemporaryFile(string fileName, string contentType, string fileDownloadName)
        {
            var bytes = System.IO.File.ReadAllBytes(fileName);
            System.IO.File.Delete(fileName);
            return File(bytes, contentType, fileDownloadName);
        }
    }

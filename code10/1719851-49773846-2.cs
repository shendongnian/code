    [Route("[controller]"]
    public class FileController : Controller {
        //POST File/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<ActionResult> Upload(UploadFilesViewModel model, IEnumerable<IFormFile> files) {
            //...
        }
        
        //GET File/Download
        [HttpGet]
        [Route("Download")]
        public async Task<IActionResult> Download(string filePath) {
            //...
        }
    }

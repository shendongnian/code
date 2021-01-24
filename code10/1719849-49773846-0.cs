    [Route("[controller]"]
    public class FileController : Controller {
        [HttpPost]
        [Route("Upload")]
        public async Task<ActionResult> Upload(UploadFilesViewModel model, IEnumerable<IFormFile> files) {
            //...
        }
        [HttpGet]
        [Route("Download")]
        public async Task<IActionResult> Download(string filePath) {
            //...
        }
        
    }

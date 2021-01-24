    public class DocumentsController : Controller
    {
        // you should name the field(s) like this to make it/them difference
        private readonly IHostingEnvironment _hostingEnvironment;
    
        public DocumentsController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
    
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Save(UploadDocumentViewModel Input)
        {
            // NOTE: we don't need "/" character before the path, like "/documents"
            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "documents");
            
            // then, copy and paste your code to continue
        }
    }

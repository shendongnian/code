    [Produces("application/json")]
        [Route("api/[controller]")]
        public class FileUploadController : Controller
        {
        private IHostingEnvironment _hostingEnvironment;
    
        public FileUploadController(IHostingEnvironment hostingEnvironment)
        {
          _hostingEnvironment = hostingEnvironment;
        }
    
        [HttpPost, DisableRequestSizeLimit]
        public ObjectResult UploadFile()
        {
          try
          {
            var file = Request.Form.Files[0];
            string folderName = "Upload";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
              Directory.CreateDirectory(newPath);
            }
            string fileName = "";
            if (file.Length > 0)
            {
              fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
              string fullPath = Path.Combine(newPath, fileName);
              using (var stream = new FileStream(fullPath, FileMode.Create))
              {
                file.CopyTo(stream);
              }
            }
    
            return Ok(fileName);
          }
          catch (System.Exception ex)
          {
            return BadRequest(ex.Message);
          }
        }
      }

    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        public FileController()
        {
        }
        [HttpPost]
        [Produces("application/json")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> PostProfilePicture([FromForm]IFormFile file)
        {
            var stream = file.OpenReadStream();
            var name = file.FileName;
            return null;
        }
    }

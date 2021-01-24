    [Route("api/[controller]")]
        public class ValuesController : Controller
        {
            [HttpPost("Bytes")]
            public void Bytes([FromBody]byte[] value)
            {
    
            }
    
            [HttpPost("Form")]
            public Task<IActionResult> Form([FromForm]List<IFormFile> files)
            {
                // see https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads
                return Task.FromResult<IActionResult>(Ok());
            }
        }

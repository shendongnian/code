    using System.IO;
    using Microsoft.AspNetCore.Mvc;
    
    namespace WebApi.Controllers
    {
        [Route("api/[controller]")]
        public class UploadController : Controller
        {
            private const string FILEPATH = @"c:\temp\demo.txt";
    
            [HttpGet]
            public IActionResult JsonObject()
            {
                var file = new FileInfo(FILEPATH);
                return new OkObjectResult(new FileClass()
                {
                    Name = file.Name,
                    Content = System.IO.File.ReadAllBytes(FILEPATH)
                });
            }
    
            [HttpPost]
            public IActionResult Index([FromBody] FileClass file)
            {
                return new NoContentResult();
            }
        }
    
        public class FileClass
        {
            public string Name { get; set; }
            public byte[] Content { get; set; }
        }
    }

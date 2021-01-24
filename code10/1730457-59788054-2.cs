    using Microsoft.AspNetCore.Cors;
    ... your other usings
    
    namespace ProjectTest.Controllers
    {
        [ApiController]
        [EnableCors("CorsPolicy")] //THIS HERE needs to be the same name as set in your startup.cs
        [Route("[controller]")]
        public class FooController:Controller
        {
            [HttpGet("getTest")]
            public JsonResult GetTest()
            {
                return Json("bar");
            }
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class FooController : ODataController
    {
        [SampleActionFilter]
        [HttpGet("SomeResource")]
        public IActionResult SomeResource()
        {
            return Content("Successful access to resource - header should be set.");
        }
    }

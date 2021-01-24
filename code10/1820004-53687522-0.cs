    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [Route("[action]")]
        public IActionResult Test() => Content("Hello World!");
    }

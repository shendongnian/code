    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [HttpGet("{id}")]
        [HttpGet("verify")]
        [AcceptVerbs("GET")]
        public IActionResult Verify(string id)
        {
            return Ok();
        }
    }

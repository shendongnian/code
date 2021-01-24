    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        // GET api/values        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() {
            return new string[] { "value1", "value2" };
        }
        // GET api/values/some_name 
        [HttpGet("{name}")]
        public IActionResult GetByName(string name) {
            return Ok();
        }
    }

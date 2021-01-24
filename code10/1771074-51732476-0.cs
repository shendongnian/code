    [Route(api/[controller])]
    public class SampleController : Controller {
        //GET api/sample/1
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            //...
        }
    }

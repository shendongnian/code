    [Route(api/[controller])]
    public class SampleController : Controller {
        //GET api/sample/1
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            //...
        }
        //POST api/sample
        [HttpGet("{id}")]
        public IActionResult Post(Sample model) {
            //...
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }
    }

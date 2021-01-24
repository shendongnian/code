    public class ApplicationsController : Controller {
        //...code removed for brevity
        //Matches POST /{area}/applications
        [HttpPost("[area]/[controller]")]
        public async Task<IActionResult> Create([FromBody]ApplicationViewModel model) {
            //...code removed for brevity
        }
        //Matches PUT /{area}/applications
        [HttpPut("[area]/[controller]")]
        public async Task<IActionResult> Update([FromBody]ApplicationViewModel model) {
            //...code removed for brevity
        }
        
        //...code removed for brevity
    }

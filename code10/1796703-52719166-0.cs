    public class ProductsController : Controller
    {
        [HttpGet]
        [Route("controller/action")]
        public IActionResult List() {
            // ...
        }
    
        [HttpGet]
        [Route("controller/action/{id}")]
        public IActionResult Edit(int id) {
            // ...
        }
    }

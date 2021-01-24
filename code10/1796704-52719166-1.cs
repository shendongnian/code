    [RoutePrefix("Products")]
    public class ProductsController : Controller
    {
        [HttpGet]
        [Route("api/List")]
        public IActionResult List() {
            // ...
        }
    
        [HttpGet]
        [Route("api/Edit/{id}")]
        public IActionResult Edit(int id) {
            // ...
        }
    }

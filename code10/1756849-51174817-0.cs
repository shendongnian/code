    [Route("~/products")]
    public class ProductsController : Controller
    {
        [HttpGet("{id:int}")]
        public IActionResult ById(int id)
        {
            ...
        }
    }

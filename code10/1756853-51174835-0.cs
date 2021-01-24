    [Route("[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet("[action]/{id:int}")] // /Products/ById/5
        public IActionResult ById(int id)
        {
            ...
        }
    }

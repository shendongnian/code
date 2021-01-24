    [Route("/api/products")]
    public class ProductsController : Controller
    {
        [HttpGet("by-id/{id:int}")] // /api/products/by-id/5
        public IActionResult ById(int id)
        {
            ...
        }
    }

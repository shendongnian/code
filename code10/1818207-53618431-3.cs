    [Route("api/{controller}")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = DataAccess.GetProductsFromDb();
            if (products is null)
            {
                return Ok(products);
            }
            else
            {
                return NotFound("Item not found!");
            }
        }
    }

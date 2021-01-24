    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
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
                return BadRequest("Error retrieving products list");
            }
        }
    }

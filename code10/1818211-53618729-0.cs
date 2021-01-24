    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Product[]> GetProducts()
        {
            try
            {
                Product[] products = DataAccess.GetProductsFromDb();
                return products;
            }
            catch 
            {
                return StatusCode(500, "Error retrieving products list");
            }
        }
    }

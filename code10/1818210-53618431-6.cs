    [Route("api/{controller}")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            Products[] products;
            try
            {
                products = DataAccess.GetProductsFromDb();
            }
            catch(Exception e)
            {
                Log.Error(e, "Unable to receive products");
                return InternalServerError("Unable to retrieve products, please try again later");
            }
            if (products is null)
            {
                return BadRequest("Error retrieving products list");
            }
            else
            {
                return Ok(products);
            }
        }
    }

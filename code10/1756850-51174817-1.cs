    public class ApiProductsController : Controller
    {
        [HttpGet("{id:int}")]
        public virtual IActionResult ById(int id)
        {
            ...
        }
    }
    public class ProductsController : ApiProductsController
    {
    
        public override IActionResult ById(int id)
        {
            base.ById(id);
        }
    }

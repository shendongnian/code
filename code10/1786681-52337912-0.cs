    [Route("admin")]
    public class AdminController : Controller { }
    
    public class ProductsAdminController : AdminController
    { 
        [Route("products/list")]
        public IActionResult Index()
        {
            ...
        }
    }

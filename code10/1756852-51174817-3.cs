    namespace MyNamespace
    {
        public class ProductsController : Controller
        {
            [HttpGet("{id:int}")]
            public virtual IActionResult ById(int id)
            {
                ...
            }
        }
    }
    namespace MyOtherNamespace
    {
        public class ProductsController : MyNamespace.ProductsController
        {
    
            public override IActionResult ById(int id)
            {
                base.ById(id);
            }
        }
    }

    [Produces("application/json")]
    [Route("[controller]")]
    public class ProductController : BaseController<Product> {
        public ProductController(SiteContext context) : base(context) { }
    }

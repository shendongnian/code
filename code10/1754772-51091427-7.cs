    [Produces("application/json")]
    [Route("[controller]")]
    public class ProductController : BaseController<Product, ProductModel> {
        public ProductController(SiteContext context) : base(context) { }
        protected override ProductModel Map(Product entity) {
            return new ProductModel {
                Property1 = entity.Property1,
                //...
                PropertyN = entity.PropertyN,
            }
        }
    }

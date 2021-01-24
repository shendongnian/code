    namespace CompanyWeb.Controllers
    {
        [Route("api/[controller]")]
        public class ProductController : Controller
        {
            private IProductRepository<ProductdbData> _ProductRepository;
            public ProductController(IProductRepository<ProductdbData> productRepository)
            {
                _ProductRepository = productRepository;
            }

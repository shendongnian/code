    namespace CompanyWeb.Controllers
    {
        [Route("api/[controller]")]
        public class ProductController : Controller
        {
            private IProductRepository _ProductRepository;
            public ProductController(IProductRepository productRepository)
            {
                _ProductRepository = productRepository;
            }

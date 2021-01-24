    // I am just making this up. Not production ready
    public class ProductController : Controller
    {
        private readonly AppDbContext _dbContext;
        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(int page = 1)
        {
            var vm = new ProductListViewModel
            {
                Products = new List<ProductSummaryViewModel>()
            };
            // Get products from database
            var products = _dbContext.Products
                .AsNoTracking();
            // Setup pagination
            vm.Pager = new Pager(products.Count(), page);
            var pagedProducts = products
                .Skip((vm.Pager.CurrentPage - 1) * vm.Pager.PageSize)
                .Take(vm.Pager.PageSize)
                .ToList();
            foreach (var product in pagedProducts)
            {
                vm.Products.Add(new ProductSummaryViewModel
                {
                   ProductId = product.Id,
                   Name = product.Name
                });
            }
            return View(vm);
        }
    }

    public class HomeController : Controller
    {    
       private readonly IMemoryCache _cache;
       public IScheduledStuff _scheduledstuff;
       public HomeController(IMemoryCache cache, IScheduledStuff scheduledstuff)
       {
            _cache = cache;
            _scheduledstuff = scheduledstuff;
            _scheduledstuff.ScheduleItemsExecute();
        }
        public IActionResult Index()
        {
            ViewBag.ProductCategoryList = _cache.Get<IEnumerable<ProductCategory>>("Teststore");
            return View();
        }
    }
    
    public class ProductCategoryRepository : IProductCategoryRepository<ProductCategory>
    {
        public IEnumerable<ProductCategory> GetAllProductCategory()
        {
            return _context.ProductCategory.ToList();
        }
    }
    
    public ProductCategory()
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductCategoryDescription { get; set; }
    }
    
    public class ScheduledStuff : IScheduledStuff
    {
        private readonly DatabaseContext _context;
        IMemoryCache MemCache;
        public IProductCategoryRepository<ProductCategory> productcategoryrepository;
    
        public ScheduledStuff(DatabaseContext context, IMemoryCache memCache)
        {
            _context = context;
            MemCache = memCache;
            productcategoryrepository = new ProductCategoryRepository(_context);
        }
    
        public void ScheduleItemsExecute()
        {
            var testdata = productcategoryrepository.GetAllProductCategory();
            MemCache.Set("Teststore", testdata);
        }
    }
    
    
    public class Startup
    {
        public IProductCategoryRepository<ProductCategory> productcategoryrepository;
        public IMemoryCache memorycache;
    
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ScheduledStuff>();

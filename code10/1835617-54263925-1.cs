    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            _dbContext.ChangeTracker.LazyLoadingEnabled = false;
        
            // Your is query here
            return View();
        }
    }

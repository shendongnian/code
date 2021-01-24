    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _environment;
    
        public HomeController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
    
        public IActionResult Index()
        {
            string path = System.IO.Path.Combine(_environment.WebRootPath, "js/page/...");
    
            return View();
        }
    }

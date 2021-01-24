        public class HomeController : Controller
        {
            private readonly ILogger _logger;
            public HomeController(ILoggerFactory loggerFactory)
            {
                _logger = loggerFactory.CreateLogger<HomeController>();
            }
    
            public IActionResult Index()
            {
                return View();
            }
    
            public IActionResult Contact()
            {
                ViewData["Message"] = "Your contact page.";
                //Trace.TraceInformation("TraceInformation ---this is from contact page.....");
                _logger.LogInformation("ILogger --- this is from contact page!!!!");
                return View();
            }
    
           //other code
    }

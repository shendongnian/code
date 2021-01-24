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
        
                public IActionResult About()
                {
                    _logger.LogInformation("ILogger --- this is from contact page!!!! info");
                _logger.LogError("ILogger --- this is from contact page xxxx error");                
    
                return View();
                }
        
               //other code
        }

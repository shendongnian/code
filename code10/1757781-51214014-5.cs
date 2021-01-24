      public class HomeController : Controller
        {
            ILogger<HomeController> logger;
            public HomeController(ILogger<HomeController> logger)
            {
                this.logger = logger;
            }
            public IActionResult Index()
            {
                logger.Log(LogLevel.Information,new EventId(1001), "This is test 1");
                logger.Log(LogLevel.Information, new EventId(2001), "This is test 2");
                return View();
            } 
        }

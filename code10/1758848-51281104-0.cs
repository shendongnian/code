    private readonly ILogger _logger;
    
            public HomeController(ILogger<HomeController> logger)
            {
                _logger = logger;
            }
            void SomeMethod()
            {
                _logger.LogInformation("some log message.");
            }
            public IActionResult Index()
            {
                SomeMethod();
                return View();
            }

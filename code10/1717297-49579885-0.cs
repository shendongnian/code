    public class MyAwesomeController : Controller
    {
        private readonly ILogger _logger;
    
        public MyAwesomeController(ILogger<MyAwesomeController> logger)
        {
            // logger contains a refference to the DIed ILogger 
            // We assign it to _logger so we can reference it from other
            // methods in the class
            _logger = logger;
        }
    
        public IActionResult GetIndex()
        {
            // Log something
            //_logger.LogInformation();
            return View();
        }
    }

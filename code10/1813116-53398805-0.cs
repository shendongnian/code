    // Auto Resolved:
    public class SampleController : Controller
    {
         private readonly ILogger logger;
    
         public SampleController(ILogger logger) => this.logger = logger;
    
         public IActionResult Index()
         {
             logger.Information("...");
             ..
         }
    }
    // Will not auto resolve
    public class SampleService
    {
         private readonly ILogger logger;
    
         public SampleService(ILogger logger) => this.logger = logger;
    
         public void SampleAction()
         {
             logger.Information("...");
             ..
         }
    }

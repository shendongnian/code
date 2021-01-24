    public class YourController : Controller
    {
         private readonly ILoggingService _loggingService;
         public YourController(ILoggingService loggingService)
         {
             _loggingService = loggingService;
         }
    
         public IActionResult YourMethod()
         {
            _loggingService.WriteLog("Inside GetUserbyCredential function");
         }
    }

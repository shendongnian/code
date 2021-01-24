    public class ValuesController : Controller
    {
        private readonly LoggingService _loggingService;
        public ValuesController(LoggingService loggingService)
        {
            _loggingService = loggingService;
        }
        ...
    }

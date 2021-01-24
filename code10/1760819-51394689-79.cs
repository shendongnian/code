    public class TodoController : Controller
    {
        private readonly ILogger _logger;
    
        public TodoController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("TodoApi.Controllers.TodoController");
        }
    }

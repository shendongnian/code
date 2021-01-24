    public class TodoController : Controller
    {
        private readonly ILogger _logger;
    
        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger.CreateLogger("TodoApi.Controllers.TodoController");
        }
    }

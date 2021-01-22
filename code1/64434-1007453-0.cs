    public class ApplicationController : Controller
    {
        protected ILogger _logger { get; set; }
        
        public ApplicationController(ILogger logger)
        {
             this._logger = logger;
        }
    }

    public class RequestLoggerActionFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly MVCProContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RequestLoggerActionFilter(ILoggerFactory loggerFactory
            , IConfiguration configuration
            , MVCProContext context
            , IHttpContextAccessor httpContextAccessor)
        {
            _logger = loggerFactory.CreateLogger("RequestLogger");
            _configuration = configuration;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            var cookies = _httpContextAccessor.HttpContext.Request.Cookies;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {           
            base.OnActionExecuting(context);
        }
    }

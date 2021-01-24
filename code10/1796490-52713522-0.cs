    public class CheckValidRouteAttribute : ActionFilterAttribute
    {
        private readonly string _apiRoute;
        private readonly string _operation;
        public CheckValidRouteAttribute(string apiRoute, string operation) : base()
        {
            _apiRoute = apiRoute;
            _operation = operation;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var method = request.Method;
            if (string.Compare(method, _operation, true) != 0)
            {
                context.Result = new BadRequestObjectResult("HttpMethod did not match");
            }
        }
    }

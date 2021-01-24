    public class ObsoleteLoggingFilter : IActionFilter
    {
        private readonly ILogger _logger;
        public ObsoleteLoggingFilter(ILogger logger)
        {
            _logger = logger;
        }
        public bool AllowMultiple { get { return true; } }
        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            //check the action for obsolete, if null check the controller
            var obsoleteAttribute = actionContext
                .ActionDescriptor
                .GetCustomAttributes<ObsoleteAttribute>()
                .SingleOrDefault() ?? actionContext
                    .ControllerContext
                    .ControllerDescriptor
                    .GetCustomAttributes<ObsoleteAttribute>()
                    .SingleOrDefault();
            if (obsoleteAttribute == null)
                return continuation();
            var controller = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var user = actionContext.RequestContext.Principal.Identity.Name;
            return continuation().ContinueWith(t =>
            {
                _logger.WarnFormat("{0} is calling obsolete controller {1}", user, controller);
                return t.Result;
            });
        }
    }

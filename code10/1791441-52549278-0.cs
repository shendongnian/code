    [PortActionConstraint(5000)]
    public class HomeController : Controller
    {
       ...
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class PortActionConstraint : ActionMethodSelectorAttribute
    {
        public PortActionConstraint(int port)
        {
            Port = port;
        }
        public int Port { get; }
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            var port = routeContext.HttpContext.Request.Host.Port;
            return Port == port;
        }
    }

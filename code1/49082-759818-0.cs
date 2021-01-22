    public abstract class ControllerBase : Controller
    {
        protected override void OnActionExecuting(
            ActionExecutingContext filterContext)
        {
            var session = filterContext.RequestContext.HttpContext.Session;
            // code
        }
    }

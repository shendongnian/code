    public class SiteIdFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            bool shouldRedirect = SomeMethodToCheckViewBag();
            if (shouldRedirect)
            {
                 filterContext.Result = new new RedirectToRouteResult("SystemLogin", routeValues);
            }
        }
    }

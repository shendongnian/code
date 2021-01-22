    public class TestAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string controllerName = filterContext.RouteData["controller"];
            string actionName = filterContext.RouteData["action"];
            string verb = filterContext.HttpContext.Request.HttpMethod;
            // .. do your processing
            // if fail...
            filterContext.Result = new HttpUnauthorizedResult();
            base.OnAuthorization(filterContext);
        }
    }

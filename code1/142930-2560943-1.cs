    public class RequireHttp : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // If the request has arrived via HTTPS...
            if (filterContext.HttpContext.Request.IsSecureConnection)
            {
                filterContext.Result = new RedirectResult(filterContext.HttpContext.Request.Url.ToString().Replace("https:", "http:")); // Go on, bugger off "s"!
                filterContext.Result.ExecuteResult(filterContext);
            }
            base.OnActionExecuting(filterContext);
        }
    }

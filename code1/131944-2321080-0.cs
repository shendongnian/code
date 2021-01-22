    public sealed class MyRedirectAttributeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ActionDescriptor.IsDefined(typeof(RequireSSLAttribute), true))
            {
                filterContext.HttpContext.Response.Redirect("~/Controller/Action");
            }
            base.OnActionExecuting(filterContext);
        }
    }true

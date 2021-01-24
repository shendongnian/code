    public class CharsetAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Headers["Content-Type"] += ";charset=utf-8";
            }
    }

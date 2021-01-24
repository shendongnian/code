    public class MyAuthFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag=filterContext.HttpContext.Request.IsAuthenticated;
        }
    }

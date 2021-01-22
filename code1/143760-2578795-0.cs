    internal class Http403Result : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            // Set the response code to 403.
            context.HttpContext.Result.StatusCode = 403;
        }
    }
    public class CustomActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Result = new Http403Result();
        }
    }

    [Log]
    public ActionResult A()
    {
       ...
    }
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
             ... use context to log stuff
        }
    }

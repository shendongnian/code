    public class ControllerBase : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            NLog.LogManager.DisableLogging();
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            NLog.LogManager.EnableLogging();
        }
    }

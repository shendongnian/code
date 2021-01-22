    public abstract class ControllerBase : Controller
    {
        protected override void OnActionExecuting(
            ActionExecutingContext filterContext)
        {
            // code involving this.Session // edited to simplify
            base.OnActionExecuting(filterContext); // re-added in edit
        }
    }

    public abstract class ControllerBase : Controller
    {
        protected override void OnActionExecuting(
            ActionExecutingContext filterContext)
        {
            ViewData["user"] = "Bar";
            base.OnActionExecuting(filterContext);
        }
    }
    [HandleError]
    public class HomeController : ControllerBase
    {...}

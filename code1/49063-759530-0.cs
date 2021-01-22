    public class UserInfoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(
            ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            filterContext.Controller.ViewData["user"] = "Foo";
        }
    }
    ...
    [HandleError, UserInfo]
    public class HomeController : Controller
    {...}

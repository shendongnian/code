    public abstract class BaseController : Controller
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                ViewBag.Text = "Start new survey";
                base.OnActionExecuting(filterContext);
            }  
        }

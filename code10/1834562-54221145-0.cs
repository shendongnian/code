    public class GlobalViewBagFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           filterContext.Controller.ViewBag.UserImage = "Your Image Path";
        }
    }

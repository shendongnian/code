    public class MyFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.Controller;
            controller.ViewData["welcomeMessage"] = "Hi World!";
            controller.TempData["Access_My_TempData"] = "Some Value";
            base.OnActionExecuted(filterContext);
        }
    }

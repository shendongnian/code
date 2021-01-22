    public class ControllerBase : Controller
    {
        protected override void OnActionExecuted(
            ActionExecutedContext filterContext)
        {
            var modelBase = ViewData.Model as ModelBase;
            if (modelBase != null)
            {
                modelBase.UserName = "foo";
            }
            base.OnActionExecuted(filterContext);
        }
    }

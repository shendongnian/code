    public class ValidateAccessAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var actionName = actionContext.ActionDescriptor.ActionName;
            ......
            base.OnActionExecuting(actionContext);
        }
    }

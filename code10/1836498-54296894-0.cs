    public class DebugFilter : IActionFilter
    {
        bool enabled = false;
        IDictionary<string, object> arguments = null;
        public void OnActionExecuting(ActionExecutingContext context)
        {
            enabled = context.HttpContext.Request.Headers.ContainsKey("X-Debug");
            if (enabled)
            {
                arguments = context.ActionArguments;
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (enabled)
            {
                var controllerName = context.Controller.GetType().Name;
                var actionName = context.ActionDescriptor.DisplayName;
                context.HttpContext.Response.Headers.Add("X-Controller-Name", controllerName);
                context.HttpContext.Response.Headers.Add("X-Action-Name", actionName);
                context.HttpContext.Response.Headers.Add("X-Action-Model", JsonConvert.SerializeObject(arguments));
            }
        }
    }

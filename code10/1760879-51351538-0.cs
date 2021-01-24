    public class IgnoreMissingContentType : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Request.Headers["Content-Type"] = "application/json";
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }

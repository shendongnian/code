    public class MyFilter:IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // pre-processing here
            var queryArgs = context.HttpContext.Request.Query;
        }
    
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // post-processing here
        }
    }

    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var url=context.HttpContext.Request.Path.ToString()
            if(url.Contains("/api/values/get/1"))
            {
                 //do something
            }
        }
    }

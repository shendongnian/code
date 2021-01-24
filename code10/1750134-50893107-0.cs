    public class MyActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.Result = new BadRequestObjectResult(new {Error = "JWT Token is expired."});
        }
    }

    public class Err : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result as BadRequestObjectResult;
            // you can access result.Value here
        }
    }

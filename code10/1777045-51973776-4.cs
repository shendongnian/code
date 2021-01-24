    public class CustomActionFilter: ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                // Before Execution
            }
     
            public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
            {
                //On Execution
            }
        }

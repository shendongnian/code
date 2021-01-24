    public abstract class GenericActionFilter : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            if (await OnBeforeActionExecutionAsync(context))
            {
                var executed = await next();
    
                if (executed.Exception != null && !executed.ExceptionHandled)
                {
                    await OnExceptionAsync(executed); // #2.
                }
                else
                {
                    // NOTE: You might want to use executed here too.
                    await OnAfterActionExecutionAsync(context);
                }
            }
        }
    
        // ...
    
        public virtual Task OnExceptionAsync(ActionExecutedContext context) // #1.
        {
            return Task.CompletedTask;
        }
    }

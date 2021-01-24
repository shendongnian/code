    public class ExceptionFilter : GenericActionFilter
    {    
        public override Task OnExceptionAsync(ActionExecutedContext context) // #1, #2.
        {
            Logger.Error(context.Exception); // #2 (single parameter).
            context.Result = new ContentResult { ... };
            context.ExceptionHandled = true; // #3.
            return Task.CompletedTask;
        }
    }

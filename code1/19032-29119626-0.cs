    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception;
            if(exception is SqlTimeoutException)
            {
                //do some handling for this type of exception
            }
        }
    }

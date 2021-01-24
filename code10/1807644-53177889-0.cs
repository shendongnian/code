    public class MyExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context.Exception is SqlException)
            {
                //do something...
            }
            else if (context.Exception is HttpListenerException)
            {
                //do something...
            }
            else
            {
                //do something else...
            }
        }
    }

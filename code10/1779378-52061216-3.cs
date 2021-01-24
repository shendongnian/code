    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task Invoke(HttpContext context, ILogger logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            { 
                await HandleExceptionAsync(context, ex, logger);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger logger) 
        {
            logger.Log(exception);
            //do something
            return context.Response.WriteAsync(... something ...); //Maybe some JSON message or something
        }
    }

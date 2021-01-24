    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
    
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(httpContext, ex);
            }
        }
    
        private static void HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception is BadHttpRequestException badRequestException && badRequestException.Message == "Request body too large.")
            {
                context.Response.StatusCode = (int) HttpStatusCode.RequestEntityTooLarge;
            }
        }
    }

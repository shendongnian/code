    public class ExceptionHandlingMiddleware
    {
        private RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext context)
        {
            try
            {
                _next.Invoke(context);
            }
            catch (Exception ex)
            {
                context.ResponseCode = //choose response
                context.Response.WriteAsync("Some custom text");
            }
        }
    }

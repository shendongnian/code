    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorWrappingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception exception)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(...); // change you response body if needed
            }
        }
    }

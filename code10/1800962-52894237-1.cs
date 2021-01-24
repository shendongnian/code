    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        public CorrelationIdMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.OnStarting((Func<Task>)(() =>
            {
                httpContext.Response.Headers.Add("X-Correlation-Id", Guid.NewGuid().ToString());
                return Task.CompletedTask;
            }));
            try
            {
                await this._next(httpContext);
            }
            catch (Exception)
            {
                //add additional exception handling logic here 
                //...
                httpContext.Response.StatusCode = 500;
            }
        }
    }

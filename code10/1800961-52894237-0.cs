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
                await this._next(httpContext);
            }
        }

    public class CorrelationMiddleware
    {
        private readonly RequestDelegate _next;
    
        public CorrelationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task Invoke(HttpContext context)
        {
            context.Request.Headers.TryGetValue("Correlation-Id-Header", out var correlationIds);
    
            var correlationId = correlationIds.FirstOrDefault() ?? Guid.NewGuid().ToString();
    
            CorrelationContext.SetCorrelationId(correlationId);
    
            using (LogContext.PushProperty("Correlation-Id", correlationId))
            {
                await _next.Invoke(context);
            }
        }
    }

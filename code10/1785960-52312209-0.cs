        public class CorrelationMiddleware
        {
        readonly RequestDelegate _next;
        public CorrelationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            context.Request.Headers.TryGetValue(Headers.Correlation, out StringValues correlationId);
            using (LogContext.PushProperty("Correlation-Id", correlationId.FirstOrDefault()))
            {
                await _next.Invoke(context);
            }
        }
    }

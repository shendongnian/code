    public class RequestDiagnosticsMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestDiagnosticsMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // I don't yet called Controller/Action.
            //log the essential parts of the request here
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }

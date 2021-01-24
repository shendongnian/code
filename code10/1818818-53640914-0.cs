    internal class PathRewritingMiddleware
    {
        private readonly RequestDelegate _next;
        public PathRewritingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext context)
        {
            context.Request.Path = "elsewhere/" + context.Request.Path;
            return _next(context);
        }
    }

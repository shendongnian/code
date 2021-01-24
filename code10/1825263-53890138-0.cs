    public class LogUserNameMiddleware
    {
        private readonly RequestDelegate next;
    
        public LogUserNameMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
    
        public async Task InvokeAsync(HttpContext context)
        {
            using(LogContext.PushProperty("UserName", context.User.Identity.Name))
            {
                await next(context);
            }       
        }
    }

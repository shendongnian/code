     public class CommonResponserMiddleware
    {
        private readonly RequestDelegate _next;
             
        public CommonResponserMiddleware(RequestDelegate next)
        {
            _next = next;
                    
        }
        public async Task Invoke(HttpContext context)
        {
            //process context.Request
            await _next.Invoke(context);
            //process context.Response
            
        }
    }
    public static class CommonResponserExtensions
    {
        public static IApplicationBuilder UseCommonResponser(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CommonResponserMiddleware>();
        }
    }

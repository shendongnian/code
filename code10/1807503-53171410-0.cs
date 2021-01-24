app.UseMiddleware<MyErrorHandling>();
    public class MyErrorHandling
    {
        private readonly RequestDelegate _next;
        public MyErrorHandling(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                // Do stuff?
                await context.Response.WriteAsync("it broke. :(");
            }
        }
    }

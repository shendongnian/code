    public class AppMessageMiddleware
    {
        private readonly RequestDelegate _next;
        public AppMessageMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
        }
        //Note the new parameter here:                vvvvvvvvvvvvvvvvvvvvv
        public async Task Invoke(HttpContext context, FooService fooService)
        {
            context.Response.OnStarting(() =>
            {
                var fooCount = fooService.Foos.Count;
                return Task.CompletedTask;
            });
            await _next(context);
        }
    }

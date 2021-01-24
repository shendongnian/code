    public static class AppExtensions
    {
        public static IApplicationBuilder Get(this IApplicationBuilder app,
                                                string path, Func<string> run) 
            => app.Use(async (context, next) =>
                {
                    if (context.Request.Path == path)
                        await context.Response.WriteAsync(run());
                    else await next();
                });
    }

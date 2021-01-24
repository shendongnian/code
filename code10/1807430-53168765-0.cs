    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.IsLocal())
                {
                    // Forbidden http status code
                    context.Response.StatusCode = 403;
                    return;
                }
                await next.Invoke();
            });
        }
    }

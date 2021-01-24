    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            /* configure any services you need here */
        }
        public void Configure(IApplicationBuilder app)
        {
            // Output a "hello world" to the user who accesses the server
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello, world!");
            });
        }
    }

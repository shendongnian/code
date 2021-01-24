    public class Startup
    {
        private static void HandleMapTest1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 1");
            });
        }
    
        public void Configure(IApplicationBuilder app)
        {
            app.Map("/map1", HandleMapTest1);
    
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from non-Map delegate. <p>");
            });
        }
    }

    public class Startup
    {
       //...    
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {   
            app.UseDemoRoutes();
        }
    }
    
    public static class ApplicationExtensions
    {
        public static IApplicationBuilder UseDemoRoutes(this IApplicationBuilder app)
        {
            app.UseMvc(routes => new DemoRouter(routes));
    
            return app;
        }
    }
    
    public class DemoRouter
    {    
        public DemoRouter(IRouteBuilder routes)
        {
            ConfigureRoutes(routes);
            // ConfigureMoreRoutes(routes);
        }
    
        private void ConfigureRoutes(IRouteBuilder routes)
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        }
    }

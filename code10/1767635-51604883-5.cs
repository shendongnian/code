            public void ConfigureServices(IServiceCollection services)
            {
                // ...
        
                services.AddMvc();     // add mvc services here
        
                // ...
            }
        
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
        
                app.UseMvcWithDefaultRoute();   // use mvc  here
        
                app.Run(context => {
                    return context.Response.WriteAsync("Hello world");
                });
            }
        

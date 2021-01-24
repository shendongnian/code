    public void Configure(IApplicationBuilder app, IHostingEnvironment env){
        // ...
    
        // app.UseMvcWithDefaultRoute();
    
        app.UseStaticFiles();     // add a StaticFiles middleware here
    
        app.Run(async context => {
            await context.Response.WriteAsync("Hello,world");
        });
    }

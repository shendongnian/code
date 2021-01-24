    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        // ...
    
        app.UseIdentityServer();
        app.UseMvc(...);
    }

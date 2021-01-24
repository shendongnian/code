    public void ConfigureServices(IServiceCollection services)
    {
        // Add the needed services, e.g. services.AddMvc();
        services
            .AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                // Change the options as needed
            });            
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseMvc();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseStaticFiles();
        app.UseMvcWithDefaultRoute();
        Rotativa.AspNetCore.RotativaConfiguration.Setup(env);
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        Utilities.StateHelper.HostingEnvironment = env;
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();
        app.UseMvcWithDefaultRoute();
    }

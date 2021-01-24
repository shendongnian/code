    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();
        **app.UseSession();**
        app.UseHttpContextItemsMiddleware();
        app.UseMvc();
    }

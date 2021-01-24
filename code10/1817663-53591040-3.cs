    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();
        app.UseSession(); //<--- add this line
        app.UseHttpContextItemsMiddleware();
        app.UseMvc();
    }

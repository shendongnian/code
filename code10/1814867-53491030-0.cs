    //config found in some tutorial, sometimes you can find with z X-XSRF-TOKEN, didnt test it
    public void ConfigureServices(IServiceCollection services)
    {
    (...)
    services.AddAntiforgery(x => x.HeaderName = "X-CSRF-TOKEN");
    services.AddMvc();
    }
    (...)
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IAntiforgery antiforgery)
            {
                (...)
                app.Use(next => context =>
                {
                    if (context.Request.Path == "/")
                    {
                        //send the request token as a JavaScript-readable cookie
                        var tokens = antiforgery.GetAndStoreTokens(context);
                        context.Response.Cookies.Append("CSRF-TOKEN", tokens.RequestToken, new CookieOptions { HttpOnly = false });
                    }
                    return next(context);
                });
                app.UseAuthentication();
                app.UseStaticFiles(); //new configs supposed to be before this line

    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddMvc();
        services.AddAuthentication(o =>
        {
            o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }).AddCookie(options =>
        {
            options.AccessDeniedPath = new PathString("/Account/Login/");
            options.LoginPath = new PathString("/Account/Login/");
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
                options.TokenValidationParameters = new TokenValidationParameters {...};
        });
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ...
        app.UseAuthentication();
        app.UseMvcWithDefaultRoute();
        ...
    }    

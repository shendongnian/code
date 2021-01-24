    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddAuthorization(options =>
        {
            options.AddPolicy("defaultpolicy", b =>
            {
                b.RequireAuthenticatedUser();
            });
            options.AddPolicy("apipolicy", b =>
            {
                b.RequireAuthenticatedUser();
                b.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
            });
        });
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = "CustomScheme";
        })
        .AddCookie()
        .AddJwtBearer(options =>
        {
            // Bearer Logic
        })
        .AddOAuth("CustomScheme", options =>
        {
            // Oauth Logic
        });
    }

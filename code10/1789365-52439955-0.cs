    public void ConfigureServices(IServiceCollection services)
    {
            services.AddAuthentication(options =>
                    {
                        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    })
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                        {
                            options.LoginPath = "/auth";
                            //https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.cookiebuilder?view=aspnetcore-2.1
                            options.Cookie = new CookieBuilder
                            {
                                Name = "CustomCookie",
                                HttpOnly = false
                            };
                        });
    }
    
    public async void Configure(IApplicationBuilder app)
    {
         app.UseAuthentication();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
       ILoggerFactory loggerFactory)
    {
       app.UseCookieAuthentication(new CookieAuthenticationOptions
       {                
          AuthenticationScheme = "AuthenticationScheme",
          LoginPath = new PathString("/Account/Login"),
          AccessDeniedPath = new PathString("/Common/AccessDenied"),
          AutomaticAuthenticate = true,
          AutomaticChallenge = true
       });
    }

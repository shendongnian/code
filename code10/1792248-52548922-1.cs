    public class Startup
    {
       public void Configuration(IAppBuilder app)
       {
          //
       }
       public void ConfigureServices(IServiceCollection services)
       {
        services.AddMvc();
        //...
    
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "bearer";
            options.DefaultChallengeScheme = "bearer";
        }).AddJwtBearer("bearer", options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("the server key used to sign the JWT token is here, use more than 16 chars")),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero //the default for this setting is 5 minutes
            };
            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("Token-Expired", "true");
                    }
                    return Task.CompletedTask;
                }
            };
        });
    }
    }

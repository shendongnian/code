    public static void ConfigureAuth(IServiceCollection services)
    {
        services
            .AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    // Must validate the signing key
                    ValidateIssuerSigningKey = true,
                    // Must validate the life time
                    ValidateLifetime = true,
                    // The issuer may vary in a multitenant scenario,
                    // that's why we not valid the issuer.
                    ValidateIssuer = false,
                    ValidIssuer = o.ClaimsIssuer,
    
                    // Allowing passing a token among multiple services (audiences).
                    ValidateAudience = false,
                    ValidAudience = "",
    
                    // Does not require expiration
                    RequireExpirationTime = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
    }

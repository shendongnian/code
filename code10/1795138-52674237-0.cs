    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        var key = Encoding.ASCII.GetBytes("this-is-the-secret");
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    // 
                    ValidIssuer = "my-auth-server",
                    ValidateIssuer = true,
                    // 
                    ValidAudience = "my-resource-server",
                    ValidateAudience = true,
                    //
                    ValidateLifetime = true,
                };
            });
    }

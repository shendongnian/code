    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        var key = Encoding.ASCII.GetBytes("this-is-the-secret");
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
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

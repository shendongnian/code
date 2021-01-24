    services.Configure<JwtSettings>(Configuration.GetSection("jwt"));
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
    {
        var config = services.BuildServiceProvider().GetRequiredService<IOptions<JwtSettings>>().Value;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = config.Issuer
        };
    });

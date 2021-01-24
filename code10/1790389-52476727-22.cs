    services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("yourConnectionString"));
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(opt =>
        {
            opt.SecurityTokenValidators.Clear();
            // or just pass connection multiplexer directly, it's a singleton anyway...
            opt.SecurityTokenValidators.Add(new RevokableJwtSecurityTokenHandler(services.BuildServiceProvider()));
        });

    services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost",
        builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .SetPreflightMaxAge(TimeSpan.FromDays(5)));
    });

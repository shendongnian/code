    services.AddCors(o => o.AddPolicy("Policy", builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins("[THE_DOMAIN_TO_UNBLOCK]");
        }));

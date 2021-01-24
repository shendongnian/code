    services.AddScoped<ModelStateInvalidFilter>(sp =>
    {
        var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
        return new ModelStateInvalidFilter(
            sp.GetRequiredService<ApiBehaviorOptions>(),
            loggerFactory.CreateLogger<ModelStateInvalidFilter>());
        });
    };

    services.AddAuthorization(options =>
    {
        if (_environment.IsProduction())
        {
            options.AddPolicy("AtLeast21", policy =>
                    policy.Requirements.Add(new MinimumAgeRequirement(21)));
        }
    });

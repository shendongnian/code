    if (_environment.IsProduction())
    {
        services.AddAuthorization(options =>
        {
            if (Configuration.IsPolicyEnabled("AtLeast21")) //check your configure from somewhere
            {
                options.AddPolicy("AtLeast21", policy =>
                    policy.Requirements.Add(new MinimumAgeRequirement(21)));
            }
        });
    }

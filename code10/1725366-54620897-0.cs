    services.AddAuthentication(
            options =>
            {
                options.DefaultAuthenticateScheme = "Cookie"
                options.DefaultChallengeScheme = Constants.NoOpSchema;
                options.DefaultSignInScheme = "Cookie";
            }
        )
        .AddCookie("Cookie")
        .AddScheme<CustomAuthOptions, CustomAuthHandler>(Constants.NoOpSchema, "Custom Auth", o => { });

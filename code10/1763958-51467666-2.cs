    services.AddAuthorization(options =>
    {
        options.AddPolicy("ADDSUB", policy =>
            policy.RequireAssertion(context =>
                context.User.HasClaim(c => c.Type == "Addition" && c.Value == "add") || 
                context.User.HasClaim(c => c.Type == "Substraction" && c.Value == "subs")));
    });

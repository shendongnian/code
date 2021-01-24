    services.AddAuthorization(options => 
    {
        options.AddPolicy("IsAdmin", policy => policy.Requirements.Add(new IsAdminRequirement()));
        options.AddPolicy("IsStaff", policy => policy.Requirements.Add(new IsStaffRequirement()));
    }
    services.AddSingleton<IAuthorizationHandler, MyRequirementHandler>();

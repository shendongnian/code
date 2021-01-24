    if (_environment.IsProduction())
    {
        services.AddAuthorization(options =>
        {
            if (Configuration.IsPolicyEnabled("AtLeast21"))
            {
                options.AddPolicy("AtLeast21", policy =>
                {
                    if (Configuration.IsPolicyEnabled("AtLeast21")) //check your configure from somewhere
                    {
                        options.AddPolicy("AtLeast21", policy =>
                          policy.Requirements.Add(new MinimumAgeRequirement(21)));
                    }
                    if (Configuration.RequireClaim("EmployeeNumber"))//another exentions. To Do
                    {
                        policy.RequireClaim("EmployeeNumber");
                    }
                    if (Configuration.RequireRole("Employee"))//another exentions. To Do
                    {
                        policy.RequireRole("Employee");
                    }
                    if (Configuration.RequireUserName("WhateverUserName"))//another exentions. To Do
                    {
                        policy.RequireUserName("WhateverUserName");
                    }
                });
            }
        });
    }

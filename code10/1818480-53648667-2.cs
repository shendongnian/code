        services.AddAuthorization(options =>
            {
                options.AddPolicy("ManageAllCalculationPolicy", policy =>
                        policy.RequireAssertion(context =>
                            context.User.HasClaim(c => c.Type == "BadgeId")));
                options.AddPolicy("ManageAllPriceListPolicy", policy =>
                        policy.RequireAssertion(context =>
                            context.User.HasClaim(c => c.Type == "aaaa")));
            });

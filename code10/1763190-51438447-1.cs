    services.AddAuthorization(options =>
            {
                // require user to have cookie auth or jwt bearer token
                options.AddPolicy("Authenticated",
                    policy => policy
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme, CookieAuthenticationDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser());
                                  options.AddPolicy("CIAuthoringManagement",
                    policy => policy.Requirements.Add(new CIAuthoringManagementRequirement()));
                           });
    services.AddTransient<IAuthorizationHandler, CIAuthoringManagement>();

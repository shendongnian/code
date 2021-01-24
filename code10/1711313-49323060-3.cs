    services.AddMvc(config =>
                {
                    var defaultPolicy = new AuthorizationPolicyBuilder(new[] { IdentityServerAuthenticationDefaults.AuthenticationScheme, IdentityConstants.ApplicationScheme })
                        .RequireAuthenticatedUser()
                        .Build();
                    config.Filters.Add(new AuthorizeFilter(defaultPolicy));
                })

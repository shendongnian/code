    services.AddMvc(config =>
            {
                //var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                //config.Filters.Add(new Microsoft​.AspNetCore​.Mvc​.Authorization.AuthorizeFilter(policy));
                config.Filters.Add(typeof(ExceptionFilter));
            });

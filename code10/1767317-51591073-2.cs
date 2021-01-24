    //...
    serviceProvider = services.BuildServiceProvider();
    var userRepository = serviceProvider.GetService<IUserRepository>();
    // Add framework services
    services.AddMvc(
        config =>
        {
            var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
            config.Filters.Add(new RolesAuthorizationFilter(userRepository));
        });

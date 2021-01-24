    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(o =>
        {
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            o.Filters.Add(new AuthorizeFilter(policy));
        });
    }

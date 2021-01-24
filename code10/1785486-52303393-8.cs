    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvcCore(options =>
        {
            // workaround: https://github.com/aspnet/Mvc/issues/7809
            options.AllowCombiningAuthorizeFilters = false;
        })
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
        .AddAuthorization();
        // This is not relevant for you, but just to show how policyserver is implemented.
        // The bottom line is that you can implement this anyway you like.
        // this sets up the PolicyServer client library and policy
        // provider - configuration is loaded from appsettings.json
        services.AddPolicyServerClient(Configuration.GetSection("Policy"))
            .AddAuthorizationPermissionPolicies();
    }
    public void Configure(IApplicationBuilder app)
    {
        app.UseAuthentication();
        // add this middleware to make roles and permissions available as claims
        // this is mainly useful for using the classic [Authorize(Roles="foo")] and IsInRole functionality
        // this is not needed if you use the client library directly or the new policy-based authorization framework in ASP.NET Core
        app.UsePolicyServerClaims();
        app.UseMvc();
    }

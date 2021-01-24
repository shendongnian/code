    // Inside the public void Configure(IApplicationBuilder app)
    var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
    var scope = scopeFactory.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    new UserRoleSeed(roleManager).Seed(); // Where UserRoleSeeding happens
    

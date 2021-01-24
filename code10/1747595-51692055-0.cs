    private static async Task CreateRole(RoleManager<IdentityRole> roleManager, 
    ILogger<DbInitializer> logger, string role)
    {
      logger.LogInformation($"Create the role `{role}` for application");
      IdentityResult result = await roleManager.CreateAsync(new IdentityRole(role));
      if (result.Succeeded)
      {
        logger.LogDebug($"Created the role `{role}` successfully");
      }
      else
      {
        ApplicationException exception = new ApplicationException($"Default role `{role}` cannot be created");
        logger.LogError(exception, GetIdentiryErrorsInCommaSeperatedList(result));
        throw exception;
      }
    }
    private static async Task<ApplicationUser> CreateDefaultUser(UserManager<ApplicationUser> userManager, ILogger<DbInitializer> logger, string displayName, string email)
    {
      logger.LogInformation($"Create default user with email `{email}` for application");
      ApplicationUser user = new ApplicationUser
      {
        DisplayUsername = displayName,
        Email = email,
        UserName = email
      };
      IdentityResult identityResult = await userManager.CreateAsync(user);
      if (identityResult.Succeeded)
      {
        logger.LogDebug($"Created default user `{email}` successfully");
      }
      else
      {
        ApplicationException exception = new ApplicationException($"Default user `{email}` cannot be created");
        logger.LogError(exception, GetIdentiryErrorsInCommaSeperatedList(identityResult));
        throw exception;
      }
      ApplicationUser createdUser = await userManager.FindByEmailAsync(email);
      return createdUser;
    }
    private static async Task SetPasswordForUser(UserManager<ApplicationUser> userManager, ILogger<DbInitializer> logger, string email, ApplicationUser user, string password)
    {
      logger.LogInformation($"Set password for default user `{email}`");
      IdentityResult identityResult = await userManager.AddPasswordAsync(user, password);
      if (identityResult.Succeeded)
      {
        logger.LogTrace($"Set password `{password}` for default user `{email}` successfully");
      }
      else
      {
        ApplicationException exception = new ApplicationException($"Password for the user `{email}` cannot be set");
        logger.LogError(exception, GetIdentiryErrorsInCommaSeperatedList(identityResult));
        throw exception;
      }
    }

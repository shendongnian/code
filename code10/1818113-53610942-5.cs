    public class ExcludeRoleHandler : AuthorizationHandler<ExcludeRoleRequirement>
    {
      private readonly UserManager<IdentityUser> _manager;
      public ExcludeRoleHandler(UserManager<IdentityUser> manager)
      {
        _manager = manager;
      }
      protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
        ExcludeRoleRequirement requirement)
      {
        var usersInRole = await _userManager.GetUsersInRoleAsync(requirement.Role);
        if (usersInRole.Count() == 0)
        {
          context.Succeed(requirement);
        }
        return Task.CompletedTask;
      }
    }

    public class ExcludeRoleHandler : AuthorizationHandler<ExcludeRoleRequirement>
    {
      private readonly UserManager<IdentityUser> _manager;
      public ExcludeRoleHandler(UserManager<IdentityUser> manager)
      {
        _manager = manager;
      }
      protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, 
        ExcludeRoleRequirement requirement)
      {
        var usersInRole = await _manager.GetUsersInRoleAsync(requirement.Role);
        if (!usersInRole.Any())
        {
          context.Succeed(requirement);
        }
        return Task.CompletedTask;
      }
    }

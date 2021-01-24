    public class ExcludeRoleRequirement : IAuthorizationRequirement
    {
      public string Role { get; private set; }
      public ExcludeRoleRequirement(string role)
      {
        Role = role;
      }
    }
     
    public class ExcludeRoleHandler : AuthorizationHandler<ExcludeRoleRequirement>
    {
      protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
        ExcludeRoleRequirement requirement)
      {
        if (!context.User.IsInRole(requirement.Role))
        {
          context.Succeed(requirement);
        }
        return Task.CompletedTask;
      }
    }

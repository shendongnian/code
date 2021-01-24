    public class AgentsActivityAuthorizationHandler : AuthorizationHandler<UserNameRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserNameRequirement requirement)
        {
            if (context.User.IsInRole("Administrator") || context.User.IsInRole("Manager") || context.User.Identity.Name == requirement.UserName)
            {
                context.Succeed(requirement);
            }
            return Task.FromResult(0);
        }
    }
    public class UserNameRequirement : IAuthorizationRequirement
    {
        public UserNameRequirement(string username)
        {
            this.UserName = username;
        }
        public string UserName { get; set; }
    }

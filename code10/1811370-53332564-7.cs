    public class MyPolicyRequirementHandler : AuthorizationHandler<MyPolicyRequirement>
    {
        public MyPolicyRequirementHandler()
        {
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MyPolicyRequirement requirement)
        {
            var user= context.User;
            if (user.Identity.IsAuthenticated)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

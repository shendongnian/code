        public class CountryControllerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Country>
    {
        public override async Task HandleAsync(AuthorizationHandlerContext context)
        {
            if (context.Resource is Country)
            {
                foreach (var req in context.Requirements.OfType<OperationAuthorizationRequirement>())
                {
                    await HandleRequirementAsync(context, req, (Country)context.Resource);
                }
            }
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       OperationAuthorizationRequirement requirement,
                                                       Country resource)
        {
            if (requirement.Name == Operations.ReadDetail.Name &&
                context.User.Claims.FirstOrDefault(a => a.Type == "userType")?.Value == "customer"
                )
            {
                context.Succeed(requirement);
            }
            if (requirement.Name == Operations.Create.Name &&
                context.User.Claims.FirstOrDefault(a => a.Type == "userType")?.Value == "1"
                )
            {
                context.Succeed(requirement);
            }
            if (requirement.Name == Operations.Update.Name &&
                context.User.Claims.FirstOrDefault(a => a.Type == "userType")?.Value == "1"
                )
            {
                context.Succeed(requirement);
            }
            if (requirement.Name == Operations.Delete.Name &&
               context.User.Claims.FirstOrDefault(a => a.Type == "userType")?.Value == "1"
               )
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

    public class RoleRequirementHandler : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var pendingRequirements = context.PendingRequirements.ToList();
            foreach (var requirement in pendingRequirements)
            {
                if (requirement is IsAdminRequirement)
                {
                    bool isAuthorized = DoYourCheck();
                    if (isAuthorized)
                    {
                        context.Succeed(requirement);
                    }
                }
                else if (requirement is IsStaffRequirement)
                {
                    bool isAuthorized = DoYourCheck();
                    if (isAuthorized)
                    {
                        context.Succeed(requirement);
                    }
                }
            }            
            return Task.CompletedTask;
        }
    }
    

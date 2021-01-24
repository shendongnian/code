    public class DynamicRoleHandler : AuthorizationHandler<DynamicRole>
    {
        private readonly AuthorizationOptions _options;
        public DynamicRoleHandler(IOptionsMonitor<AuthorizationOptions> options)
        {
            _options = options.CurrentValue;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DynamicRole requirement)
        {
            if (context.User.IsInRole(_options.Role))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }

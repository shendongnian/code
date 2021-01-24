    public class EnvironmentAuthorize : IAuthorizationRequirement
    {
        public string Environment { get; set; }
        public EnvironmentAuthorize(string env)
        {
            Environment = env;
        }
    }
    public class ProductionAuthorizeHandler : AuthorizationHandler<EnvironmentAuthorize>
    {
        private readonly IHostingEnvironment envionment;
        public ProductionAuthorizeHandler(IHostingEnvironment env)
        {
            envionment = env;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EnvironmentAuthorize requirement)
        {
            if (requirement.Environment != envionment.EnvironmentName)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

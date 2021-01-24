    public class ProductionAuthorize : IAuthorizationRequirement
    {
        public string Environment { get; set; }
        public ProductionAuthorize(string env)
        {
            Environment = env;
        }
    }
    public class ProductionAuthorizeHandler : AuthorizationHandler<ProductionAuthorize>
    {
        private readonly IHostingEnvironment envionment;
        public ProductionAuthorizeHandler(IHostingEnvironment env)
        {
            envionment = env;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ProductionAuthorize requirement)
        {
            if (requirement.Environment == envionment.EnvironmentName)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

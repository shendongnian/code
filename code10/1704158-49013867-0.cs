        public class TokenRequirementHandler : AuthorizationHandler<TokenRequirement>
    {
        public IMemoryCache Cache { get; set; }
        public TokenRequirementHandler(IMemoryCache memoryCache)
        {
            Cache = memoryCache;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TokenRequirement requirement)
        {
            return Task.Run(() => { //access the cache and then
            context.Succeed(requirement); });
        }
    }

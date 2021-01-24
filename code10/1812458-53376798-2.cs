    public class IpCheckRequirement : IAuthorizationRequirement
    {
        public bool IpClaimRequired { get; set; } = true;
    }
    public class IpCheckHandler : AuthorizationHandler<IpCheckRequirement>
    {
        public IpCheckHandler(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }
        private IHttpContextAccessor HttpContextAccessor { get; }
        private HttpContext HttpContext => HttpContextAccessor.HttpContext;
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IpCheckRequirement requirement)
        {
            Claim ipClaim = context.User.FindFirst(claim => claim.Type == "ipaddress");
            // No claim existing set and and its configured as optional so skip the check
            if(ipClaim == null && !requirement.IpClaimRequired)
            {
                // Optional claims (IsClaimRequired=false and no "ipaddress" in the claims principal) won't call context.Fail()
                // This allows next Handle to succeed. If we call Fail() the access will be denied, even if handlers
                // evaluated after this one do succeed
                return Task.CompletedTask;
            }
            if (ipClaim.Value = HttpContext.Connection.RemoteIpAddress?.ToString())
            {
                context.Succeed(requirement);
            }
            else
            {
                // Only call fail, to guarantee a failure, even if further handlers may succeed
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }

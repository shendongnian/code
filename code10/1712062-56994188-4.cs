    public class MyClaimsService : DefaultClaimsService
    {
        private readonly UserManager _userManager;
        public MyClaimsService(IProfileService profile, ILogger<DefaultClaimsService> logger, UserManager userManager) : base(profile, logger)
        {
            _userManager = userManager;
        }
        protected override IEnumerable<Claim> GetStandardSubjectClaims(ClaimsPrincipal subject)
        {
            var sub = subject.GetSubjectId();
            var user = _userManager.FindByIdAsync(sub).GetAwaiter().GetResult();
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, user?.GlobalUid.ToString() ?? sub),
                new Claim(JwtClaimTypes.AuthenticationTime, subject.GetAuthenticationTimeEpoch().ToString(), ClaimValueTypes.Integer),
                new Claim(JwtClaimTypes.IdentityProvider, subject.GetIdentityProvider())
            };
            claims.AddRange(subject.GetAuthenticationMethods());
            return claims;
        }
    }

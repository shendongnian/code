    public static class IIdentityExtensions
    {
        public static string UserId(this IIdentity identity)
        {
            return identity.GetClaimValue("userId");
        }
        public static string GetClaimValue(this IIdentity identity, string claimType)
        {
            return identity
                .AsClaimsIdentity()
                .Claims.FirstOrDefault(c => c.Type == claimType)?.Value;
        }
        private static ClaimsIdentity AsClaimsIdentity(this IIdentity identity)
        {
            if (!(identity?.IsAuthenticated ?? false))
                throw new UnauthorizedAccessException("User not logged-in");
            return identity as ClaimsIdentity;
        }
    }

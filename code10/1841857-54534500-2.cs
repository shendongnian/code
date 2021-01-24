        public static class IdentityExtensions
        {
            public static int GetUserId(this ClaimsPrincipal identity)
            {
                Claim claim = identity?.FindFirst(CustomClaimTypes.UserId);
                if (claim == null)
                    return 0;
                return int.Parse(claim.Value);
            }
            public static string GetName(this ClaimsPrincipal identity)
            {
                Claim claim = identity?.FindFirst(ClaimTypes.Name);
                return claim?.Value ?? string.Empty;
            }
        }

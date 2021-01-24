    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    
    public class ClaimsTransformer : IClaimsTransformation
    { 
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var ci = (ClaimsIdentity) principal.Identity;
            var c = new Claim(ci.RoleClaimType, "Admin");
            ci.AddClaim(c);
            return Task.FromResult(principal);
        }
    }

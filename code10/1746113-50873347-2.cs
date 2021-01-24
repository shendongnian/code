      public class AuthorisationProviderClient : IAuthorisationProviderClient
      {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
    
        public AuthorisationProviderClient(
          UserManager<ApplicationUser> userManager, 
          RoleManager<IdentityRole> roleManager)
        {
          this.userManager = userManager;
          this.roleManager = roleManager;
        }
    
        public async Task<bool> IsInRole(ClaimsPrincipal user, string role)
        {
          var appUser = await GetApplicationUser(user);
          return await userManager.IsInRoleAsync(appUser, role);
        }
    
        public async Task<List<Claim>> GetAuthorisationsForUser(ClaimsPrincipal user)
        {
          List<Claim> claims = new List<Claim>();
          var appUser = await GetApplicationUser(user);
    
          var roles = await userManager.GetRolesAsync(appUser);
    
          foreach (var role in roles)
          {
            var idrole = await roleManager.FindByNameAsync(role);
    
            var roleClaims = await roleManager.GetClaimsAsync(idrole);
    
            claims.AddRange(roleClaims);
          }
    
          return claims;
        }
    
        public async Task<bool> HasClaim(ClaimsPrincipal user, string claimValue)
        {
          Claim required = null;
          var appUser = await GetApplicationUser(user);
    
          var userRoles = await userManager.GetRolesAsync(appUser);
    
          foreach (var userRole in userRoles)
          {
            var identityRole = await roleManager.FindByNameAsync(userRole);
    
            // this only checks the AspNetRoleClaims table
            var roleClaims = await roleManager.GetClaimsAsync(identityRole);
            required = roleClaims.FirstOrDefault(x => x.Value == claimValue);
    
            if (required != null)
            {
              break;
            }
          }
    
          if (required == null)
          {
            // this only checks the AspNetUserClaims table
            var userClaims = await userManager.GetClaimsAsync(appUser);
            required = userClaims.FirstOrDefault(x => x.Value == claimValue);
          }
          
          return required != null;
        }
    
        private async Task<ApplicationUser> GetApplicationUser(ClaimsPrincipal user)
        {
          return await userManager.GetUserAsync(user);
        }
      }

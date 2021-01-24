    public class MyClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public MyClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }
    
        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);
    
            long dealershipID = user.ActiveDealershipID;
            ((ClaimsIdentity)principal.Identity).AddClaim(new Claim("DealershipID", dealershipID.ToString()));
    
            return principal;
        }
    }

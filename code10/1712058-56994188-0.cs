    public sealed class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
    {
        public MyUserClaimsPrincipalFactory(UserManager userManager, RoleManager<ApplicationRole> roleManager, IOptions<IdentityOptions> optionsAccessor)
                : base(userManager, roleManager, optionsAccessor)
        {}   
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        { 
            var identity = await base.GenerateClaimsAsync(user);
            var sub = identity.FindFirst("sub");
            if (sub == null)
                return identity; 
            identity.RemoveClaim(sub);
            identity.AddClaim(new Claim("sub", user.GlobalUid.ToString()));
            return identity;
        }
    }

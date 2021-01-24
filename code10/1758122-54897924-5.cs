    public class SignInManager<TUser> : Microsoft.AspNetCore.Identity.SignInManager<TUser> 
        where TUser : class
    {
        public SignInManager(
            UserManager<TUser> userManager, 
            IHttpContextAccessor contextAccessor, 
            IUserClaimsPrincipalFactory<TUser> claimsFactory, 
            IOptions<IdentityOptions> optionsAccessor, 
            ILogger<Microsoft.AspNetCore.Identity.SignInManager<TUser>> logger, 
            IAuthenticationSchemeProvider schemes) 
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
        }
        public async override Task SignOutAsync()
        {
            await Context.SignOutAsync(IdentityConstants.ApplicationScheme); // <- 
        }
    }

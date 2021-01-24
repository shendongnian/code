    public class AppUserService : AspNetIdentityUserService<AppUser, Guid>
    {
        private AppUserManager _userManager;
        public AppUserService(AppUserManager userManager)
            : base(userManager)
        {
            _userManager = userManager;
        }
        public async override Task GetProfileDataAsync(ProfileDataRequestContext ctx)
        {
            var id = Guid.Empty;
            if (Guid.TryParse(ctx.Subject.GetSubjectId(), out id))
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(Constants.ClaimTypes.PreferredUserName, user.UserName),
                        new Claim(Constants.ClaimTypes.Email, user.Email),
                        new Claim(Constants.ClaimTypes.GivenName, user.FirstName),
                        new Claim(Constants.ClaimTypes.FamilyName, user.LastName)
                    };
                    ctx.IssuedClaims = claims;
                }
            }
        }
    }

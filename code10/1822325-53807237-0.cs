    public class IdentityProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        public IdentityProfileService(IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, UserManager<ApplicationUser> userManager,
            ApplicationDbContext dbContext)
        {
            _claimsFactory = claimsFactory;
            _userManager = userManager;
            _db = dbContext;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            if (user == null)
            {
                throw new ArgumentException("");
            }
            
            var principal = await _claimsFactory.CreateAsync(user);
            var claims = principal.Claims.ToList();
            var login = await _userManager.GetLoginsAsync(user);
             login.Select(l => l.LoginProvider).ToList().ForEach(x => claims.Add(new Claim("authenticate_type", x)));
            context.IssuedClaims = claims;
        }
        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }

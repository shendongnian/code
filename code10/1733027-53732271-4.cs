    public class IdentityManagerCore : IIdentityManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public IdentityManagerCore(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IIdentityResult> CreateAsync(IApplicationUser user)
        {
            ApplicationUser realUser = new ApplicationUser()
            {
                Id = user.Id,
                TemporaryToken = user.TemporaryToken,
                AccessFailedCount = user.AccessFailedCount,
                ConcurrencyStamp = user.ConcurrencyStamp,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                LockoutEnabled = user.LockoutEnabled,
                LockoutEnd = user.LockoutEnd,
                NormalizedEmail = user.NormalizedEmail,
                NormalizedUserName = user.NormalizedUserName,
                PasswordHash = user.PasswordHash,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                RequiresPasswordCreation = user.RequiresPasswordCreation,
                SecurityStamp = user.SecurityStamp,
                TwoFactorEnabled = user.TwoFactorEnabled,
                UserName = user.UserName
            };
            var result = await _userManager.CreateAsync(realUser);
            return ConvertToInterface(result);
        }
        private IIdentityResult ConvertToInterface(IdentityResult result)
        {
            IIdentityResult realResult = new IdentityResultCore();
            realResult.Succeeded = result.Succeeded;
            realResult.Errors = result.Errors?.Select(x => x.Description).ToList();
            return realResult;
        }
    }
    public class IdentityResultCore : IdentityResult, IIdentityResult
    {
           private IEnumerable<string> _errors;
        private bool _succeed;
        public new bool Succeeded
        {
            get => base.Succeeded || _succeed;
            set => _succeed = value;
        }
        public new List<string> Errors
        {
            get => base.Errors?.Select(x => x.Description).ToList() ?? _errors?.ToList();
            set => _errors = value;
        }
    }

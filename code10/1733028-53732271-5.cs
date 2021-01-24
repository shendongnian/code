    public class IdentityManagerMvc : IIdentityManager
    {
        private readonly UserManager<ApplicationUserMvc, string> _userManager = null;
        private readonly RoleManager<ApplicationRoleMvc, string> _roleManager = null;
        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }
        public IdentityManagerMvc(DatabaseContextMvc dbContext)
        {
            var userStore =
                new UserStore<ApplicationUserMvc, ApplicationRoleMvc, string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>(dbContext);
            var roleStore = new RoleStore<ApplicationRoleMvc, string, ApplicationUserRole>(dbContext);
            _userManager = new UserManager<ApplicationUserMvc, string>(userStore);
            _roleManager = new RoleManager<ApplicationRoleMvc, string>(roleStore);
            _userManager.UserValidator = new UserValidator<ApplicationUserMvc>(_userManager) { AllowOnlyAlphanumericUserNames = false };
            if (DataProtectionProvider == null)
            {
                DataProtectionProvider = new MachineKeyProtectionProvider();
            }
            _userManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUserMvc, string>(DataProtectionProvider.Create("Identity"));
        }
        public async Task<IIdentityResult> CreateAsync(IApplicationUser user)
        {
            ApplicationUserMvc realUser = new ApplicationUserMvc()
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
            IIdentityResult realResult = new IdentityResultMvc();
            realResult.Succeeded = result.Succeeded;
            realResult.Errors = result.Errors?.ToList();
            return realResult;
        }
    }
    public class IdentityResultMvc : IdentityResult, IIdentityResult
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
            get => base.Errors?.ToList() ?? _errors?.ToList();
            set => _errors = value;
        }
    }

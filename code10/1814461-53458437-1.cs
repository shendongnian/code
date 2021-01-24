    public class MYUserManager : UserManager<IdentityUser>, IMYUserManager
    {
        public MYUserManager(IUserStore<IdentityUser> store, IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<IdentityUser> passwordHasher, IEnumerable<IUserValidator<IdentityUser>> userValidators, 
            IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators, ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<IdentityUser>> logger) 
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
        public override Task<IdentityUser> FindByIdAsync(string userId)
        {
            return base.FindByIdAsync(userId);
        }
        //Removed other overridden methods for brevity; They also call the base class method
    }

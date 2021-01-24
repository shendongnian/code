    public class PortalDbContext : IdentityDbContext<PortalUser>
    {
        public PortalDbContext(string connectionString)
            : base(connectionString, throwIfV1Schema: false)
        {
        }
    
        public static PortalDbContext Create(string connectionString)
        {
            return new PortalDbContext(connectionString);
        }
    }
    
    public class PortalUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<PortalUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    
            // Add custom user claims here
            return userIdentity;
        }
    }
    
    public class PortalUserManager : UserManager<PortalUser>
    {
        public PortalUserManager(IUserStore<PortalUser> store) : base(store)
        {
        }
    
        public static PortalUserManager Create(string connectionString)
        {
            UserStore<PortalUser> userStore = new UserStore<PortalUser>(PortalDbContext.Create(connectionString));
    
            PortalUserManager manager = new PortalUserManager(userStore);
    
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<PortalUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true                
            };
    
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
    
            return manager;
        }
    
        public async Task<IdentityResult> RegisterUser(string email, string password)
        {
            PortalUser user = new PortalUser { UserName = email, Email = email };
    
            return await this.CreateAsync(user, password);
        }
    }

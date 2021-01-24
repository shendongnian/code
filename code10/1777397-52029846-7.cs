        public class ApplicationUserManager : UserManager<ApplicationUser, string>
        {
            public ApplicationUserManager(IUserStore<ApplicationUser, string> store)
                : base(store)
            {
            }
            public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
            {
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser, ApplicationRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>(context.Get<ApplicationDbContext>()));

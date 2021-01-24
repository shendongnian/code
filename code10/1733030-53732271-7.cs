    public class ApplicationUserManager : UserManager<ApplicationUserMvc, string>
    {
        public ApplicationUserManager(IUserStore<ApplicationUserMvc, string> store)
            : base(store)
        {//look at where i used applicationUserMvc
        }
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var userStore =
                new UserStore<ApplicationUserMvc, ApplicationRoleMvc, string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>(context.Get<DatabaseContextMvc>());
            //ApplicationUserLogin,UserRole,UserClaim are self created but just override IdentityUserLogin (for example).
            var manager = new ApplicationUserManager(userStore);
        }
      ...
    }
 

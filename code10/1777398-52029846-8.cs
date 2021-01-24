        public class ApplicationRoleManager : RoleManager<ApplicationRole>
        {
            public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store) { }
            public static ApplicationRoleManager Create(
                IdentityFactoryOptions<ApplicationRoleManager> options,
                IOwinContext context)
            {
                return new ApplicationRoleManager(new RoleStore<ApplicationRole>(context.Get<ApplicationDbContext>()));
            }
        }

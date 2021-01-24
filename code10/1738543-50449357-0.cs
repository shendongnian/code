        public class ApplicationRoleManager : RoleManager<Role>
        {
           public ApplicationRoleManager(IRoleStore<Role, string> store) : base(store)
           {
           }
           public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
           {
             var roleStore = new RoleStore<Role>(context.Get<SecurityDbContext>());
             return new ApplicationRoleManager(roleStore);
           }
        }

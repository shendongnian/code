    public class DatabaseContextMvc : IdentityDbContext<ApplicationUserMvc, ApplicationRoleMvc, string, ApplicationUserLogin,
        ApplicationUserRole, ApplicationUserClaim>
    {
        public DatabaseContextMvc() : base("DatabaseContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            
            //Database.SetInitializer<DatabaseContextMvc>(null);
        }
        public void SetTimeout(int minutes)
        {
            this.Database.CommandTimeout = minutes * 60;
        }
        public static DatabaseContextMvc Create()
        {
            return new DatabaseContextMvc();
        }
    }

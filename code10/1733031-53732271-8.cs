    public class DatabaseContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        private IConfiguration _config;
        public string ConnectionString { get; }
        public DatabaseContext(IConfiguration config) : base()
        {
            _config = config;
            var connectionString = config.GetConnectionString("DatabaseContext");
            ConnectionString = connectionString;
        }
        public void SetTimeout(int minutes)
        {
            Database.SetCommandTimeout(minutes * 60);
        }
        public virtual DbSet<Address> Addresses { get; set; }
        public static DatabaseContext Create(IConfiguration config)
        {
            return new DatabaseContext(config);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //setup code for the DbContextOptions
            optionsBuilder
                .UseSqlServer(ConnectionString, 
                    providerOptions => providerOptions.CommandTimeout(60))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

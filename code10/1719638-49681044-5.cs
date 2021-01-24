    public class MainContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        // .....
    
        public MainContext(IDatabaseConnection connection)
            : base(connection.NameOrConnectionString)
        {
            Database.SetInitializer<MainContext>(null);
        }
    }

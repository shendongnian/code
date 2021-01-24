    public class AppDataContext : DbContext
    {
        public AppDataContext() : base("name=DBConnection") { }
        public DbSet<User> Users { get; set; }
    }

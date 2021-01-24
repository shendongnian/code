    public class SomeContext : DbContext
    {
        public SomeContext() : base("name=DefaultConnection")
        {
        }
    
        public static SomeContext Create()
        {
            return new SomeContext();
        }
    
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    
    }

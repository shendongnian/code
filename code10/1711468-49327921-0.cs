    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options)
        { }
    
        public DbSet<UserAccount> Users { get; set; }
    }

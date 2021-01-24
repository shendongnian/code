    public class FarmDbContext : DbContext
    {
        public FarmDbContext(DbContextOptions<FarmDbContext> options) : base(options) { }
    
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }

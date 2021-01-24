    public class AppContext : DbContext
        {
            public AppContext (DbContextOptions<AppContext> options) : base(options)
            {
            }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            }
            public virtual DbQuery<Business> Business { get; set; }
            
        }

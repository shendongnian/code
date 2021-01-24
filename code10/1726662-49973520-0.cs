    public TestDbContext:DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> option) : base(option)
        {
        
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
             relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Users> Users { get; set; }

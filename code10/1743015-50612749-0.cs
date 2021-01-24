    public class ClassAEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassBId { get; set; }
        public ClassBEntity ClassB { get; set; }
    }
    public class ClassBEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ClassAEntity> ClassAs { get; set; }
    }
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Configure relationships
            builder.Entity<ClassAEntity>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).IsRequired();
                b.HasOne(x => x.ClassB)
                    .WithMany(y => y.ClassAs)
                    .HasForeignKey(x => x.ClassBId);
                b.ToTable("ClassA");
            });
            builder.Entity<ClassBEntity>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).IsRequired();
                b.ToTable("ClassB");
            });
        }
        public DbSet<ClassAEntity> ClassAs { get; set; }
        public DbSet<ClassBEntity> ClassBs { get; set; }
    }

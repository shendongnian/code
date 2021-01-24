    public class SchoolContext : DbContext
        {
            public SchoolContext() : base("SchoolContext")
            {
            }
            public DbSet<Student> Students { get; set; }
            public DbSet<StudentMap> StudentMaps { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                modelBuilder.Entity<StudentMap>().HasKey(x => new { x.MapID });
            }
        }

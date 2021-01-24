    public class SomeContext : DbContext
    {
        public SomeContext() : base("name=DefaultConnection")
        {
        }
    
        public static SomeContext Create()
        {
            return new SomeContext();
        }
    
        public DbSet<Collaboration> Users { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Types<Entity>().Configure(c =>
            {
                c.HasKey(e => e.Id);
                c.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                c.Property(e => e.CreatedBy)
                    .IsUnicode(false)
                    .HasMaxLength(255);
                c.Property(e => e.UpdateBy)
                    .IsUnicode(false)
                    .HasMaxLength(255);
            });
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }

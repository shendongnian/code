    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new MyEntityConfiguration());
    }
    internal class MyEntityConfiguration : EntityTypeConfiguration<MyEntity>
    {
        internal MyEntityConfiguration()
        {
            this.Property(e => e.Value).HasPrecision(38, 18);
        }
    }
 

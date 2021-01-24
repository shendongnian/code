    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Model1EntityConfiguration());
        modelBuilder.ApplyConfiguration(new Model2EntityConfiguration());
        // ...
    }
...
    internal sealed class Model1EntityConfiguration : EntityConfiguration<Model1>
    {
        public override void Configure(EntityTypeBuilder<Model1> builder)
        {
            base.Configure(builder); // <-- here's the key bit
            // ...; e.g.
            builder.Property(c => c.Name).HasMaxLength(80).IsRequired();
        }
    }

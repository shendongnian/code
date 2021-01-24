    internal class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.Property1).HasConversion(p => p.ToString(), p => (Guid?)Guid.Parse(p));
            // ... Other base-specific config here
        }
    }

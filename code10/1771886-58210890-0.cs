    public class HasDisplayIdEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IHasDisplayId
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.DisplayId).IsRequired();
            builder.HasIndex(e => e.DisplayId);
        }
    }

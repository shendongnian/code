    public class ModelOneConfiguration : BaseConfiguration<ModelOne>
    {
        public override void Configure(EntityTypeBuilder<ModelOne> builder)
        {
            base.Configure(builder);
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.LastName).IsRequired();
            entity.Property(e => e.Email).IsRequired();
        }
    }

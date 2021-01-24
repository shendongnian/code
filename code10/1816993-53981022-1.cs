    public class MyEntityWithVarcharMaxConfiguration
        : IEntityTypeConfiguration<MyEntityWithVarcharMax>
    {
        public void Configure(EntityTypeBuilder<MyEntityWithVarcharMax> builder)
        {
            ConfigurationHelper.ConfigureVarcharMax(builder.Property(e => e.MyVarcharMaxProperty));
        }
    }

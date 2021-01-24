    public class CommonEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    	where TEntity : Common
    {
    	public void Configure(EntityTypeBuilder<TEntity> builder)
    	{
    		builder.Property(p => p.ID)
    			.Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
    		builder.Property(p => p.CreatedOn)
    			.Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
    		builder.Property(p => p.CreatedBy)
    			.Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
    	}
    }

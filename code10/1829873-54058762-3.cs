    public class BaseEntityConfigurations<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            //CreatedDate 
            builder.Property(x => x.DateCreated).HasDefaultValueSql("GETDATE()");
            //Updated Date
            builder.Property(x => x.DateModified).HasDefaultValueSql("GETDATE()");
        }
    }

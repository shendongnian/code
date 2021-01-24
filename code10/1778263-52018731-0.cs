    public class KeyedEntityMap<TEntity, TId> : IEntityTypeConfiguration<TEntity>
        where TEntity : KeyedEntityBase<TId>
        where TId : struct
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        //       ^^^
        {
            // Primary Key
            builder.HasKey(t => t.Id);
    
            // Properties
            builder.Property(t => t.Id).HasColumnName("id").ValueGeneratedOnAdd();
        }
    }
    
    public class AuditableEntityMap<TEntity, TId> : KeyedEntityMap<TEntity, TId>
        //                                                 ^^^
        where TEntity : AuditableEntity<TId>
        where TId : struct
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        //       ^^^
        {
            base.Configure(builder); // <<<
            // Properties
            builder.Property(t => t.DateCreated).HasColumnName("DateCreated");
            builder.Property(t => t.DateModified).HasColumnName("DateModified");           
        }
    }

    public abstract class BaseEntityConfiguration<TEntityType> : IEntityTypeConfiguration<TEntityType>
        where TEntityType : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntityType> builder)
        {
            builder.HasKey(entity => entity.Guid);
    
            // The created timestamp has a default value of the current system time for when the entity
            // was created in the database. This value cannot be changed after it is set
            builder.Property(entity => entity.CreatedAtTime)
                    .HasColumnType("datetime")
                    .HasValueGenerator(typeof(CurrentDateTimeGenerator))
                    .ValueGeneratedOnAdd();
    
            // The updated timestamp has a default value of the minimum date time value and will only
            // generate a new date time when the entity has been updated
            builder.Property(entity => entity.UpdatedAtTime)
                    .HasColumnType("datetime")
                    .HasDefaultValue(DateTime.MinValue)
                    .HasValueGenerator(typeof(CurrentDateTimeGenerator))
                    .ValueGeneratedOnUpdate();
        }
    }

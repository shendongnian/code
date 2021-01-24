    public class MilitaryUnitConfiguration : BaseEntityConfiguration<MilitaryUnit>
    {
        public override void Configure(EntityTypeBuilder<MilitaryUnit> builder)
        {
            base.Configure(builder);
    
            // The unit name can only be 50 characters long and is unique
            builder.Property(entity => entity.Name)
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50)
                    .IsRequired();
    
            builder.HasAlternateKey(entity => entity.Name);
    
            // The unit has a description that can be up to 100 character long
            builder.Property(entity => entity.Description)
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100);
    
            // The unit has multiple members
            builder.HasMany<MilitaryMember>(entity => entity.Members);
    
            // The unit has multiple sections
            builder.HasMany<MilitaryUnitSection>(entity => entity.Sections);
        }
    }

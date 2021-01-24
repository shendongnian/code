    public class PlanetConfig : BaseEntityTypeConfiguration<Planet>
    {
        public override void Configure(EntityTypeBuilder<Planet> builder)
        {
            builder.Property(p => p.ID).ValueGeneratedOnAdd();
            // Follows the default convention but added to make a difference :)
            builder.HasMany(p => p.Moons)
                .WithOne(m => m.Planet)
                .IsRequired()
                .HasForeignKey(m => m.PlanetID);
            base.Configure(builder);
        }
    }
    
    public class MoonConfig : BaseEntityTypeConfiguration<Moon>
    {
        public override void Configure(EntityTypeBuilder<Moon> builder)
        {
            builder.Property(p => p.ID).ValueGeneratedOnAdd();
            base.Configure(builder);
        }
    }

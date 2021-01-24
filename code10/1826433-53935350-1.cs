    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(u => u.StudentId)
            builder.HasOne(u => u.Address)
            .WithOne(b => b.Student)
            .HasForeignKey<Address>(b => b.StudentId);
        }
    }
    

    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(u => u.StudentId)
            builder.HasOne(u => u.Student)
                   .WithOne(b => b.Address)
                   .HasForeignKey<Address>(b => b.StudentId);
        }
    }
    

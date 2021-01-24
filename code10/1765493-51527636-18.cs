            public partial class Mother
            {
                public Mother()
                {
                    MotherAddresses = new HashSet<MotherAddress>();
                }
                [Key, Column("ID")]
                public int Id { get; set; }
                [StringLength(50)]
                public string Name { get; set; }
                [InverseProperty("Mother")]
                public ICollection<MotherAddress> MotherAddresses { get; set; }
            }
            public partial class MotherAddress
            {
                [Key, Column(Order = 0)]
                public int MotherId { get; set; }
                [Key, Column(Order = 1)]
                public int AddressType { get; set; }
                [StringLength(50)]
                public string Address { get; set; }
                [ForeignKey("MotherId")]
                [InverseProperty("MotherAddress")]
                public Mother Mother { get; set; }
            }
            public enum AddressType
            {
                Physical,
                Mailing,
            }
            public static class MotherExtension
            {
                public static MotherAddress MailingAddress(this Mother mom)
                {
                    return mom.Address(AddressType.Mailing);
                }
                public static MotherAddress PhysicalAddress(this Mother mom)
                {
                    return mom.Address(AddressType.Physical);
                }
                public static MotherAddress Address(this Mother mom, AddressType addressType)
                {
                    return mom.MotherAddresses.FirstOrDefault(x => x.AddressType == addressType);
                }
            }
            // here is in your DbContext
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<MotherAddress>(entity =>
                {
                    entity.HasKey(e => new { e.MotherId, e.AddressType });
                    entity.HasOne(d => d.Mother)
                        .WithMany(p => p.MotherAddress)
                        .HasForeignKey(d => d.MotherId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_MotherAddress_Mother");
                });
             
            }

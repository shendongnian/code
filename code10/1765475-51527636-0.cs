    public class Mother
    {
        [Key]
        public int MomId { get; set; }
        //no any foreign key to MotherAddress in this model
        [InverseProperty("Mother")]
        public ICollection<MotherAddress> Addresses { get; set; }
    }
    public class MotherAddress
    {
        /// <summary>
        ///  1st primary key
        /// </summary>
        [Key, Column(Order = 0)]
        public int MomId { get; set; }
        /// <summary>
        ///  2nd primary key
        /// </summary>
        [Key, Column(Order = 1)]
        public AddressType pType { get; set; }
        [ForeignKey("MomId")]
        [InverseProperty("MotherAddress")]
        public Mother Mother { get; set; }
    }
  
    public enum AddressType
    {
        Mailing,
        Physical
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
            return mom.Addresses.FirstOrDefault(x => x.pType == addressType);
        }
    }

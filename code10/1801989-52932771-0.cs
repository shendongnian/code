    [Table("Property")]
    public partial class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyId { get; set; }
    
        [StringLength(8)]
        public string ReferenceNumber { get; set; }
        [StringLength(4)]
        public string CaseOwner { get; set; }
        public int AmountBorrowed { get; set; }
        [ForeignKey("SecurityAddressId")]
        public Address Security { get; set; }
        [ForeignKey("CorrespondenceAddressId")]
        public Address Correspondence { get; set; }
        public List<Occupier> Occupier { get; set; }
        public TenureTypes Tenure { get; set; }
        public JurisdictionTypes Jurisdiction { get; set; }
        public FunderTypes Funder { get; set; }
    
        public Property()
        {
            Occupier = new List<Occupier>();
        }
    }

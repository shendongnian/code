    public class AddUpdateAddressType
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class AddressType : AddUpdateAddressType {
        [JsonProperty(Order = -10)]
        public int Id { get; set; }
        [JsonProperty(Order = 98)]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
        [JsonProperty(Order = 99)]
        [DataType(DataType.DateTime)]
        public DateTime ModifiedOn { get; set; }
    }

    internal class Metadata
    {
        [Column(Type="Key")]
        public int ContractId { get; set; }
        [Required]
        [Column(Type="Name")]
        public string Name { get; set; }
    }

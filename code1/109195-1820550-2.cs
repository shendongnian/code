    internal class Metadata
    {
        [MappingColumn (Type="Key")]
        public int ContractId { get; set; }
        [Required]
        [MappingColumn (Type="Name")]
        public string Name { get; set; }
    }

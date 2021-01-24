    public partial class Property
    {
        // No need for the Key attribute, as this is convention
        public int Id { get; set; }
        public Address Correspondence { get; set; }
        public int CorrespondenceId { get; set; } // Not needed in this scenario, but good practice
        public ICollection<Instruction> Instructions { get; } = new HashSet<Instruction>();
    }

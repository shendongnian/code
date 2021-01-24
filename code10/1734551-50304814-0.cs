    public class ApplicationUser : ...
    {
        //... other properties
        [ForeignKey("Contracts")]
        public string ContractId { get; set; }
    }

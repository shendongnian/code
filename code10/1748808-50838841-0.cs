    public class CustomerDatabase {
        [Required]
        public string Name { get; set; }
        [StringLength(10)]
        public string AccountNumber { get; set; }
        [Required]
        public string Address { get; set; }
        //...other properties
    }
    

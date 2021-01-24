    public class Payment
    {
        public int Id {get; set;}
        
        public int? CustomerId {get; set;} //foreign key
        [ForeignKey("CustomerId")]
        public Customer Customer {get; set;}
    }

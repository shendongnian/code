    public class Customer 
    {
        [Key]
        public int ID {get; set;}
        //other properties
        //Navigation Property
        public virtual ICollection<Application> Applications{ get; set; }
    }
    
    public class Application
    {
        [Key]
        public int ID {get; set;}
        [ForeignKey("Customer")]
        public int CustomerID{get; set;}
        public DateTime ApplicationDate{get; set}
        //other properties
        public bool IsCurrent { get; set; }
    }

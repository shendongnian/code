    public class BaseClass
    {
        // Other shared properties here
        [Required] 
        public string State { get; set; }
    
        [Required]
        public string Zip { get; set; }
    }
    
    public class Endpoint1RequestModel : BaseClass
    {
        public string Address { get; set; }
        public string City { get; set; }
    }
    
    public class Endpoint2RequestModel : BaseClass
    {
        [Required]
        public string Address { get; set; }
    
        [Required]
        public string City { get; set; }
    }

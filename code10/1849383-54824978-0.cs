    public class Property 
    {
    	public long PropertyId { get; set; }
    }
    
    public class CancerType : Property 
    { 
    	// Your code
    }
    
    public class Dietary : Property 
    { 	
    	// Your code
    }
    
    public class PatientProperties : EntityModel
    {
        [Key]
        public long ID { get; set; }
    
        public long PatientID { get; set; }
    
        [ForeignKey("PatientID")]
        public Patient Patients { get; set; }
    
        public long PropertyID { get; set; }
    
        [ForeignKey("PropertyID")]
        public Property Property { get; set; }
    }

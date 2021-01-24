    public class Employee
    {        
        public int ID { get; set; }
    
        public string Place { get; set; }
    
        [IncludeinReport]
        public string BusinessVertical { get; set; }
    
        [IncludeinReport]
        public string Region { get; set; }
    
        public string Country { get; set; }
    
        [IncludeinReport]
        public string BusinessUnit { get; set; }
    }

    public class Location
    {
        public long LocationId {get;set;}
        public virtual ICollection<LocationStringMapping> LocationStringMappings {get;set;}
        //other
    }
    
    public class String
    {
        public long StringId {get;set;}
        public virtual ICollection<LocationStringMapping> LocationStringMappings {get;set;}
        //other
    }
    
    public class LocationStringMapping
    {
        [Key, Column(Order = 0)]
        public long LocationId { get; set; }
        [Key, Column(Order = 1)]
        public long StringId { get; set; }
    
        public virtual Location Location {get;set;}
        public virtual String String {get;set;}
        public DateTime DateScraped {get;set;}
    }

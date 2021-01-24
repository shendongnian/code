    public class AllowedValue
    {
        public string self { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }
    
    public class Priority
    {
        public List<AllowedValue> allowedValues { get; set; }
    }
    
    public class AllowedValue2
    {
        public string self { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }
    
    public class Components
    {
        public List<AllowedValue2> allowedValues { get; set; }
    }
    
    public class Fields
    {
        public Priority priority { get; set; }
        public Components components { get; set; }
    }
    
    public class Issuetype
    {
        public Fields fields { get; set; }
    }
    
    public class Project
    {
        public List<Issuetype> issuetypes { get; set; }
    }
    
    public class RootObject
    {
        public List<Project> projects { get; set; }
    }

    public class Person : Resource {
    
        public Person(ResourceObject resource):base(resource){
        }
    
        // Person-specific property example - Organisation
        public string Organisation { get; set; }
    }
    
    public class Computer : Resource {
        public Computer(ResourceObject resource) : base(resource) {
        }
    
        // Computer-specific property example - OperatingSystem
        public string OperatingSystem { get; set; }
    }
    
    public class Group : Resource {
    
        public Group(ResourceObject resource) : base(resource) {
        }
    
        // Group-specific property example - Members
        public string Members { get; set; }
    }

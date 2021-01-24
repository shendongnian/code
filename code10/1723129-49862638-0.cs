    [Table("Person")]
    public class Person : Base
    {
        public Guid Id {get; set; }
    
        public string Name { get; set; }
    
        public string Gender { get; set; }
        public RefValue GenderRef { get; set; }
    
        public string RelationshipStatus { get; set; }
        public RefValue RelationshipStatusRef { get; set; }
    
        public string NameSuffix { get; set; }
        public RefValue NameSuffixRef { get; set; }
    }
    
    [Table("RefValue")]
    public class RefValue : Base
    {
        public Guid Id {get; set; }
    
        public string Type { get; set; }
    
        public string Value { get; set; }
    }

    public class ObjectAttributeValue
    {
        public string value { get; set; }
    }
    
    public class Attribute
    {
        public int objectTypeAttributeId { get; set; }
        public List<ObjectAttributeValue> objectAttributeValues { get; set; }
    }
    
    public class RootObject
    {
        public int objectTypeId { get; set; }
        public List<Attribute> attributes { get; set; }
    }
 

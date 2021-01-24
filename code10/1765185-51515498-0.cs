    public class AttributeId
    {
        public string name { get; set; }
    }
    
    public class Operand
    {
        public AttributeId attributeId { get; set; }
        public string valueStr { get; set; }
    }
    
    public class Condition
    {
        public string @operator { get; set; }
        public List<Operand> operands { get; set; }
    }
    
    public class RootObject
    {
        public string targetType { get; set; }
        public string name { get; set; }
        public string message { get; set; }
        public bool active { get; set; }
        public List<string> emails { get; set; }
        public List<Condition> conditions { get; set; }
    }

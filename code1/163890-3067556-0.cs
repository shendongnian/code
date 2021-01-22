    [AttributeUsage(AttributeTargets.Class)]
    public class AttributeProviderAttribute : Attribute {
        public AttributeProviderAttribute(Type t) { Type = t; }
        public Type Type { get; set; }
    }

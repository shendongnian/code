    [AttributeUsage(AttributeTargets.Interface)]
    public class ImplementingTypeAttribute: Attribute
    {
        public Type ImplementingType { get; set; }
        public ImplementingTypeAttribute(Type implementingType)
        {
            ImplementingType = implementingType;
        }
    }

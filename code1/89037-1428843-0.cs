    [EnumHelper(typeof(Days))]
    public Days DayOfWeek { get; set; }
    
    
    [AttributeUsage(AttributeTargets.Property,AllowMultiple=true)]
    public class EnumHelper : Attribute
    {
        public Type MyEnum;
        public EnumHelper(Type enum)
        {
            MyEnum = enum;
        }
    }

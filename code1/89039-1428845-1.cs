    [AttributeUsage(AttributeTargets.Property,AllowMultiple=true)]
    public class EnumHelper : Attribute
    {
        public Type EnumType;
        public EnumHelper(Type enumType)
        {
            EnumType = enumType;
        }
    }
    ...
    [EnumHelper(typeof(Days))]
    public Days DayOfWeek { get; set; }

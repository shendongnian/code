    public enum Enum1
    {
        [Description("This is value 1")]
        value1 = 0x001,
        [Description("This is value 2")]
        value2 = 0x002,
        [Description("This is value 3")]
        value3 = 0x003
    }
    ....
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                 typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
    }

    public static class Utility
    {
        public static string Description(this Enum e)
        {
            Type t = e.GetType();
            DescriptionAttribute[] desc =
                (DescriptionAttribute[])(t.GetField(e.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false));
            return desc.Length > 0 ? desc[0].Description : e.ToString();
        }
        public static byte ToByte(this Enum e)
        {
            return (byte)e;
        }
    }

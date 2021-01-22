    public class EnumAttribute : Attribute
    {
        public string DbValue
        {
            get;
            set;
        }
    }
    public enum TGender
    {
        [EnumAttribute(DbValue = "M")]
        Male,
        [EnumAttribute(DbValue = "F")]
        Female,
        [EnumAttribute(DbValue = "U")]
        Unknown
    }
        public TGender GetEnumValue(string s)
        {
            foreach (TGender item in Enum.GetValues(typeof(TGender)))
            {
                FieldInfo info = typeof(TGender).GetField(item.ToString());
                var attribs = info.GetCustomAttributes(typeof(EnumAttribute), false);
                if (attribs.Length > 0)
                {
                    EnumAttribute a = attribs[0] as EnumAttribute;
                    if (s == a.DbValue)
                    {
                        return item;
                    }
                }
            }
            throw new ArgumentException("Invalid string value.");
        }

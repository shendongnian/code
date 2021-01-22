    public enum YourEnum
    {
        [Description("Desc1")]
        Val1,
        [Description("Desc2")]
        Val2,
        Val3,
    }
    public static string GetDescriptionFromEnum(Enum value, bool inherit)
        {
            Type type = value.GetType();
            System.Reflection.MemberInfo[] memInfo = type.GetMember(value.ToString());
            if (memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), inherit);
                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return value.ToString();
        }

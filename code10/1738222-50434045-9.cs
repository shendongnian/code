    public static string GetEnumDescription(Enum enumVal)
    {
        Type type = enumVal.GetType();
        System.Reflection.MemberInfo[] memInfo = type.GetMember(enumVal.ToString());
        object[] attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        string description = ((DescriptionAttribute)attributes[0]).Description;
        return description;
    }

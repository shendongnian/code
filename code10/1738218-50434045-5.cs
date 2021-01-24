    public static string GetEnumDescription(object enumVal)
    {
        Type type = typeof(State);
        System.Reflection.MemberInfo[] memInfo = type.GetMember(enumVal.ToString());
        object[] attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        string description = ((DescriptionAttribute)attributes[0]).Description;
        return description;
    }

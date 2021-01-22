    public static TAttribute GetEnumAttribute<TAttribute>(this Enum enumVal) where TAttribute : Attribute
    {
        var memberInfo = enumVal.GetType().GetMember(enumVal.ToString());
        return memberInfo[0].GetCustomAttributes(typeof(TAttribute), false).OfType<TAttribute>().FirstOrDefault();
    }
    public static string GetEnumDescription(this Enum enumValue) => enumValue.GetEnumAttribute<DescriptionAttribute>()?.Description ?? enumValue.ToString();

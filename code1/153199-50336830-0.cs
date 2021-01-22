    public static TEnum? GetEnumFromDescription<TEnum>(string description)
        where TEnum : struct, Enum 
    {
        var comparison = StringComparison.OrdinalIgnoreCase;
        foreach (var field in typeof(TEnum).GetFields())
        {
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (attribute != null)
            {
                if (string.Compare(attribute.Description, description, comparison) == 0)
                    return (TEnum)field.GetValue(null);
            }
            if (string.Compare(field.Name, description, comparison) == 0)
                return (TEnum)field.GetValue(null);
        }
        return null;
    }

    public static string GetDescription(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attribute = fieldInfo.GetAttribute<DescriptionAttribute>();
        return attribute != null ? attribute.Description : null;
    }

    using System.ComponentModel;
    public static string GetDescription(this Enum value)
    {
        var descriptionAttribute = (DescriptionAttribute)value.GetType()
            .GetField(value.ToString())
            .GetCustomAttributes(false)
            .Where(a => a is DescriptionAttribute)
            .FirstOrDefault();
 
        return descriptionAttribute != null ? descriptionAttribute.Description : value.ToString();
    }

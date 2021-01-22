    public static string GetAttributeDescription(this Enum enumValue)
	{
		var attribute = enumValue.GetAttributeOfType<DescriptionAttribute>();
		return attribute == null ? String.Empty : attribute.Description;
	} 

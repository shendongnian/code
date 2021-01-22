    public object CastPropertyValue(PropertyInfo property, string value) { 
	if (property == null || String.IsNullOrEmpty(value))
		return null;
	if (property.PropertyType.IsEnum)
	{
		Type enumType = property.PropertyType;
		if (Enum.IsDefined(enumType, value))
			return Enum.Parse(enumType, value);
	}
	if (property.PropertyType == typeof(bool))
		return value == "1" || value == "true" || value == "on" || value == "checked";
	else if (property.PropertyType == typeof(Uri))
		return new Uri(Convert.ToString(value));
	else
		return Convert.ChangeType(value, property.PropertyType);  }

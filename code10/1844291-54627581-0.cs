    public static void Main(string[] args)
	{
		int intValue = 2; // value from DB
		var o = new Person();
		var prop = o.GetType().GetProperty("MyGender");   
		
		// Check whether the property is a nullable. If it is, get the type of underling enum
        // Otherwise, get the type of the enum directly from the property
		var enumType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
        // Convert the int to the enum type
		var convertedValue = Enum.ToObject(enumType, intValue);
		
		prop.SetValue(o, convertedValue , null);
	}

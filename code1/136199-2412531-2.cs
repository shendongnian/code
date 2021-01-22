    public static void SetDecimalField(object obj, decimal value)
    {
		// Enumerate through all the properties to find one marked
		// with the DecimalFieldAttribute.
		PropertyInfo[] properties = obj.GetType().GetProperties();
		PropertyInfo decimalfieldproperty = null;
		foreach (PropertyInfo property in properties)
		{
			object[] attributes = property.GetCustomAttributes(typeof(DecimalFieldAttribute), true);
			if (attributes.Length == 0)
			    continue;
			// Check, or just break; when you'll not be making this error.
			if (decimalfieldproperty != null)
				throw new Exception("More than one property is marked with the DecimalFieldAttribute.");
			// Found a candidate.
			decimalfieldproperty = property;
		}
		// Check, or just assume that you'll not be making this error.
		if (decimalfieldproperty == null)
			throw new Exception("No property with the DecimalFieldAttribute found.");
		// Set the value.
		decimalfieldproperty.SetValue(obj, value, null);
	}

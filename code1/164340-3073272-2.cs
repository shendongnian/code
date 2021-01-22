	public static string GetXmlAttrNameFromEnumValue<T>(T pEnumVal)
	{
		// http://stackoverflow.com/q/3047125/194717
		Type type = pEnumVal.GetType();
		FieldInfo info = type.GetField(Enum.GetName(typeof(T), pEnumVal));
		XmlEnumAttribute att = (XmlEnumAttribute)info.GetCustomAttributes(typeof(XmlEnumAttribute), false)[0];
		//If there is an xmlattribute defined, return the name
		return att.Name;
	}
	public static T GetCode<T>(string value)
	{
		// http://stackoverflow.com/a/3073272/194717
		foreach (object o in System.Enum.GetValues(typeof(T)))
		{
			T enumValue = (T)o;
			if (GetXmlAttrNameFromEnumValue<T>(enumValue).Equals(value, StringComparison.OrdinalIgnoreCase))
			{
				return (T)o;
			}
		}
		throw new ArgumentException("No XmlEnumAttribute code exists for type " + typeof(T).ToString() + " corresponding to value of " + value);
	}

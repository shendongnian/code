	private string GetPropertyValue(PropertyInfo i, object o)
	{
		var propertyValue = p.GetValue(o, null);
		
		string stringValue;
		
		if (propertyValue.GetType() == typeof(DateTime))
		{
			stringValue = ((DateTime)propertyValue).ToString(SomeCultureInfo);
		}
		else
		{
			stringValue = propertyValue.ToString();
		}
		
		return System.Net.WebUtility.UrlEncode(stringValue);
	}

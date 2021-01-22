    public string UrlQueryStr(object data)
	{
		if (data == null)
			return string.Empty;
		object val;
		StringBuilder sb = new StringBuilder();
		foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(data))
		{
			if ((val = prop.GetValue(data)) != null)
			{
				sb.AppendFormat("{0}{1}={2}", sb.Length == 0 ? '?' : '&',
					HttpUtility.UrlEncode(prop.Name), HttpUtility.UrlEncode(val.ToString()));
			}
		}
		return sb.ToString();
	}

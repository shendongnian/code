	public static class HttpUtility2
	{
		public static string BuildQueryString<T>(T obj)
		{
			var queryString = HttpUtility.ParseQueryString(string.Empty);
	
			foreach (var property in TypeDescriptor.GetProperties(typeof(T)).Cast<PropertyDescriptor>())
			{
				var value = (property.GetValue(obj) ?? "").ToString();
				queryString.Add(property.Name, value);
			}
	
			return queryString.ToString();
		}
	}

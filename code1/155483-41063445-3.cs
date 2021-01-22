	public static class ExpandoObjectHelper
	{
		public static bool IsPropertyExist(ExpandoObject obj, string propertyName)
		{
			return ((IDictionary<String, object>)obj).ContainsKey(propertyName);
		}
	}

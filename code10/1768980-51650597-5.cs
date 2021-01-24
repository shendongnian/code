    public static T? Parse(string s)
	{
		dynamic result = null;
		Type type = typeof(T);
		string tName = type.Name;
		MethodInfo methodInfo = type.GetMethod("Parse", new[] { typeof(string) });
		result = methodInfo.Invoke(null, new[] { s });
		return result;
	}

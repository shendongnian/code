    // Uses reflection to return value of the property or null
	public static T GetPropValue<T>(object src, string propName) where T : class
	{
		return src.GetType().GetProperty(propName)?.GetValue(src, null) as T;
	}
	public static ICollection<T> ExceptTestUser<T>(this ICollection<T> list)
	{
		// If property exists, do equality check, otherwise just accept the value
		Func<T, bool> _func = i => !GetPropValue<string>(i, "Name")?.Equals("Test", StringComparison.InvariantCultureIgnoreCase) ?? true;
		return list.Where(_func).ToList();
	}

    public static bool IsParseableAs<TInput>(this string value) {
		var type = typeof(TInput);
		
		var tryParseMethod = type.GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public, Type.DefaultBinder,
			new[] { typeof(string), type.MakeByRefType() }, null);
		if (tryParseMethod == null) return false;
	
		var arguments = new[] { value, Activator.CreateInstance(type) };
		return (bool) tryParseMethod.Invoke(null, arguments);
	}

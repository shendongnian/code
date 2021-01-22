	public static TOutput ParseAs<TOutput>(this string value, TOutput defaultValue) {
		var type = typeof(TOutput);
		
		var tryParseMethod = type.GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public, Type.DefaultBinder,
			new[] { typeof(string), type.MakeByRefType() }, null);
		if (tryParseMethod == null) return defaultValue;
	
		var arguments = new object[] { value, null };
		return ((bool) tryParseMethod.Invoke(null, arguments)) ? (TOutput) arguments[1] : defaultValue;
	}

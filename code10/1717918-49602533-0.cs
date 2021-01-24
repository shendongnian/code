	static void AllowInvalidRequestHeader(string header)
	{
		var headerType = typeof(HttpRequestHeaders);
		var field = headerType
			.GetField("invalidHeaders", System.Reflection.BindingFlags.NonPublic | 
				                        System.Reflection.BindingFlags.Static) ?? 
					headerType
			.GetField("s_invalidHeaders", System.Reflection.BindingFlags.NonPublic | 
				                          System.Reflection.BindingFlags.Static);
		if (field == null) return;
		var invalidFields = (HashSet<string>)field.GetValue(null);
		invalidFields.Remove(header);
	}

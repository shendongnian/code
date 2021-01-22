	public static bool TryParse<T>(this string input, out T parsedValue)
	{
		parsedValue = default(T);
		try
		{
			var converter = TypeDescriptor.GetConverter(typeof(T));
			parsedValue = (T)converter.ConvertFromString(input);
			return true;
		}
		catch (NotSupportedException)
		{
			return false;
		}
	}

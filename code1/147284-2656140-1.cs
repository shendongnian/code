	public static T ConvertToEnum<T>(this string value) where T : Enum, new()
	{
		try
		{
			return (T)Enum.Parse(typeof(T), value);
		}
		catch
		{
			return (T)0;
		}
	}

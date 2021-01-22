	public static T ConvertToEnum<T>(this string value) where T new()
	{
		if( !typeof(T).IsEnum )
			throw new NotSupportedException( "T must be an Enum" );
		try
		{
			return (T)Enum.Parse(typeof(T), value);
		}
		catch
		{
			return (T)0;
			// return (T)Enum.Parse(typeof(T), "Unknown"));
		}
	}

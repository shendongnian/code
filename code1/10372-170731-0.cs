	public static T SafeConvert<T>(string s, T defaultValue)
	{
		if ( string.IsNullOrEmpty(s) )
			return defaultValue;
		return (T)Convert.ChangeType(s, typeof(T));
	}

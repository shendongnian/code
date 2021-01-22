	public static T GetKey<T>(this OrderedDictionary dictionary, int index)
	{
		if (dictionary == null)
		{
			return default(T);
		}
		try
		{
			return (T)dictionary.Cast<DictionaryEntry>().ElementAt(index).Key;
		}
		catch (Exception)
		{
			return default(T);
		}
	}
	public static U GetValue<T, U>(this OrderedDictionary dictionary, T key)
	{
		if (dictionary == null)
		{
			return default(U);
		}
		try
		{
			return (U)dictionary.Cast<DictionaryEntry>().AsQueryable().Single(kvp => ((T)kvp.Key).Equals(key)).Value;
		}
		catch (Exception)
		{
			return default(U);
		}
	}

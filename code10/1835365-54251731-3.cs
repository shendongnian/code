    public static void Execute<TKey, TValue>(this IEnumerable<Dictionary<TKey, TValue>> dictionaries)
	{
		var enums = (IEnumerable<IEnumerable<KeyValuePair<TKey, TValue>>>) dictionaries;
		enums.Execute();
	}

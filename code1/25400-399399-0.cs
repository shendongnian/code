	public static class DictionaryExtension
	{
		public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> items, string key)
		{
			if (items != null && items.ContainsKey(key))
			{
				return items[key];
			}
			return default(TValue);
		}
	}

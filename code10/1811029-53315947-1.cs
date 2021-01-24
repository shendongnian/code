    public static int RemoveItems(this List<Dictionary<string, object>> dictionaryList, string value)
	{
		int removed = dictionaryList
			.RemoveAll(dict => dict.TryGetValue("MyId", out object val) && value.Equals(val));
		return removed;
	}

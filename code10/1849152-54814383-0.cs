	public static IDictionary<string, string> GetHeaderValues(
		IReadOnlyList<string> keys, IHeaderDictionary headers)
	{
		return headers
		.Join(keys, h => h.Key, k => k, (h, k) => h)
		.ToDictionary(h => h.Key, h => h.Value.ToString());
	}

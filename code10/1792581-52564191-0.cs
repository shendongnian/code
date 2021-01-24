	public async Task<IEnumerable<TItem>> CacheTryGetValueSet<TItem>(string storedProcedureName, IMemoryCache cache)
	{
		IEnumerable<TItem> Enumerate(SqlDataReader source)
		{
			while (source.Read())
			{
				yield return source.GetFieldValue<TItem>(0);
			}
		}
		var reader = await OpenReaderAsync(storedProcedureName);
		if (reader.FieldCount != 1) throw new ArgumentException("That type of cache doesn't return a single column.");
		return Enumerate(reader);
	}
	public async Task<IEnumerable<KeyValuePair<TKey,TValue>>> CacheTryGetValueSet<TKey,TValue>(string storedProcedureName, IMemoryCache cache)
	{
		IEnumerable<KeyValuePair<TKey,TValue>> Enumerate(SqlDataReader source)
		{
			while (source.Read())
			{
				yield return new KeyValuePair<TKey, TValue>
				(
					source.GetFieldValue<TKey>(0),
					source.GetFieldValue<TValue>(1)
				);
			}
		}
		var reader = await OpenReaderAsync(storedProcedureName);
		if (reader.FieldCount != 2) throw new ArgumentException("That type of cache doesn't return two columns!");
		return Enumerate(reader);
	}

	public static void SplitDictionary<T1, T2>(Dictionary<T1, T2> input, out T1[] keys, out T2[] values)
	{
		keys = new T1[input.Count];
		values = new T2[input.Count];
		int i = 0;
		
		foreach ( var entry in input )
		{
			keys[i] = entry.Key;
			values[i++] = entry.Value;
		}
	}

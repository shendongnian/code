	public static void SplitDictionary<T1, T2>(Dictionary<T1, T2> input, out T1[] keys, out T2[] values)
	{
		var keyList = new List<T1>();
		var valueList = new List<T2>();
		
		foreach ( var entry in input )
		{
			keyList.Add( entry.Key );
			valueList.Add( entry.Value );
		}
		keys = keyList.ToArray();	
		values = valueList.ToArray();	
	}

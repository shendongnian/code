	/// <summary>
	/// Emulate a Dictionary (Serialization pb)
	/// </summary>
	private static string getValue(System.Collections.Specialized.StringCollection list, string key)
	{
		for (int i = 0; i * 2 < list.Count; i++)
		{
			if (list[i] == key)
			{
				return list[i + 1];
			}
		}
		return null;
	}
	/// <summary>
	/// Emulate a Dictionary (Serialization pb)
	/// </summary>		
	private static void setValue(System.Collections.Specialized.StringCollection list, string key, string value)
	{
		for (int i = 0; i * 2 < list.Count; i++)
		{
			if (list[i] == key)
			{
				list[i + 1] = value;
				return;
			}
		}
		list.Add(key);
		list.Add(value);
	}

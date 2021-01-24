	static public IEnumerable<char> GetDelimitedField(this IEnumerable<char> source, char delimiter, int index)
	{
		foreach (var c in source)
		{
			if (c == delimiter) 
			{
				if (--index < 0) yield break;
			}
		    else
			{
				if (index == 0) yield return c;
			}
		}
	}

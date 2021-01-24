    public static string InsertStrings(string text, string insertString, params int[] rangeLengths)
	{
		var sb = new StringBuilder(text);
		var indexes = new int[rangeLengths.Length];
		for (int i = 0; i < indexes.Length; i++)
			indexes[i] = rangeLengths[i] + indexes.ElementAtOrDefault(i-1) + insertString.Length;
		for (int i = 0; i < indexes.Length; i++)
		{
			if(indexes[i] < sb.Length)
				sb.Insert(indexes[i], insertString);
		}
		return sb.ToString();
	}

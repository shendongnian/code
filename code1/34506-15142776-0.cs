	public static int GetNumSubstringOccurrences(string text, string search)
	{
		int num = 0;
		int pos = 0;
		if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(search))
		{
			while (text.IndexOf(search, pos) > -1)
			{
				num++;
				pos = text.IndexOf(search, pos) + search.Length + 1;
			}
		}
		return num;
	}

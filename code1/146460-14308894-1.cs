    public static int[] AllIndexesOf(string str, string substr, bool ignoreCase = false)
	{
		if (string.IsNullOrWhiteSpace(str) ||
		    string.IsNullOrWhiteSpace(substr))
		{
			throw new ArgumentException("String or substring is not specified.");
		}
		var indexes = new List<int>();
		int index = 0;
		while ((index = str.IndexOf(substr, index, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)) != -1)
		{
			indexes.Add(index++);
		}
		return indexes.ToArray();
	}

	public static int[] ToCodePoints(string str)
	{
		if (str == null)
			throw new ArgumentNullException("str");
		var codePoints = new List<int>(str.Length);
		for (int i = 0; i < str.Length; i++)
		{
			codePoints.Add(Char.ConvertToUtf32(str, i));
			if (Char.IsHighSurrogate(str[i]))
				i += 1;
		}
		return codePoints.ToArray();
	}
	

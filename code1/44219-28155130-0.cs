	public static int[] ToCodePoints(string str)
	{
		if (str == null)
			throw new ArgumentNullException("str");
		var codePoints = new List<int>(str.Length);
		for (int i = 0; i < str.Length; i++)
		{
			if (Char.IsHighSurrogate(str[i]))
			{
				codePoints.Add(Char.ConvertToUtf32(str[i], str[i + 1]));
				i += 1;
			}
			else
				codePoints.Add(Char.ConvertToUtf32(str, i));
		}
		return codePoints.ToArray();
	}
	

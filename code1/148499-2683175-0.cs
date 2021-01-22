	public static bool ContainsPartOf(string s1, string s2, int minsize)
	{
		for (int i = 0; i <= s2.Length - minsize; i++)
		{
			if (s1.Contains(s2.Substring(i, minsize)))
				return true;
		}
		return false;
	}

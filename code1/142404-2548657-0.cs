	public static IEnumerable<string> EnclosedStrings(
		this string s, 
		string begin, 
		string end)
	{
		int beginPos = s.IndexOf(begin, 0);
		while (beginPos >= 0)
		{
			int start = beginPos + begin.Length;
			int stop = s.IndexOf(end, start);
			if (stop < 0)
				yield break;
			yield return s.Substring(start, stop - start);
			beginPos = s.IndexOf(begin, stop+end.Length);
		}			
	}

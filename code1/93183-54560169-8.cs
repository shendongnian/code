	/// <summary>
	/// Enumerates the text lines from the string.
    ///   ⁃ Mixed CR-LF scenarios are handled correctly
    ///   ⁃ String.Empty is returned for each empty line
    ///   ⁃ No returned string ever contains CR or LF
	/// </summary>
	public static IEnumerable<String> Lines(this String s)
	{
		int j = 0, c, i;
		char ch;
		if ((c = s.Length) > 0)
			do
			{
				for (i = j; (ch = s[j]) != '\r' && ch != '\n' && ++j < c;)
					;
				yield return s.Substring(i, j - i);
			}
			while (++j < c && (ch != '\r' || s[j] != '\n' || ++j < c));
	}

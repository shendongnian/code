	public static string InsertNewLine(string s, int len)
	{
		StringBuilder sb = new StringBuilder(s.Length + (int)(s.Length/len) + 1);
		int start = 0;
		for (start=0; start<s.Length-len; start+=len)
		{
			sb.Append(s.Substring(start, len));
			sb.Append(Environment.NewLine);
		}
		sb.Append(s.Substring(start));
		return sb.ToString();
	}

    public static string InsertNewLine(string source, int len = 76)
    {
    	var sb = new StringBuilder(source.Length + (int)(source.Length / len) + 1);
    	var start = 0;
    	while ((start + len) < source.Length)
    	{
    		sb.Append(source.Substring(start, len));
    		sb.Append(Environment.NewLine);
    		start += len;
    	}
    	sb.Append(source.Substring(start));
    	return sb.ToString();
    }

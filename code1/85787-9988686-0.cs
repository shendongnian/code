    static string GetRtfUnicodeEscapedString(string s)
    {
    	var sb = new StringBuilder();
    	foreach (var c in s)
    	{
    		if(c == '\\' || c == '{' || c == '}')
    			sb.Append(@"\" + c);
    		else if (c <= 0x7f)
    			sb.Append(c);
    		else
    			sb.Append("\\u" + Convert.ToUInt32(c) + "?");
    	}
    	return sb.ToString();
    }

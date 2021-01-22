    static void Main(string[] args)
    {
    	// ë
    	char[] ca = Encoding.Unicode.GetChars(new byte[] { 0xeb, 0x00 });
    	var sw = new StreamWriter(@"c:/helloworld.rtf");
    	sw.WriteLine(@"{\rtf
    {\fonttbl {\f0 Times New Roman;}}
    \f0\fs60 H" + GetRtfUnicodeEscapedString(new String(ca)) + @"llo, World!
    }"); 
    	sw.Close();
    }
    
    static string GetRtfUnicodeEscapedString(string s)
    {
    	var sb = new StringBuilder();
    	foreach (var c in s)
    	{
    		if (c <= 0x7f)
    			sb.Append(c);
    		else
    			sb.Append("\\u" + Convert.ToUInt32(c) + "?");
    	}
    	return sb.ToString();
    }

        private static string DecodeQuotedPrintables(string input, string charSet)
        {
            try
        	{
        		enc = Encoding.GetEncoding(CharSet);
        	}
        	catch
        	{
        		enc = new UTF8Encoding();
        	}
        
        	var occurences = new Regex(@"(=[0-9A-Z]{2}){1,}", RegexOptions.Multiline);
        	var matches = occurences.Matches(input);
        	
    	foreach (Match match in matches)
      	{
        		try
        		{
        			byte[] b = new byte[match.Groups[0].Value.Length / 3];
        			for (int i = 0; i < match.Groups[0].Value.Length / 3; i++)
        			{
        				b[i] = byte.Parse(match.Groups[0].Value.Substring(i * 3 + 1, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
        			}
        			char[] hexChar = enc.GetChars(b);
        			input = input.Replace(match.Groups[0].Value, hexChar[0].ToString());
       		}
        		catch
        		{ ;}
        	}
        	input = input.Replace("=\r\n", "").Replace("=\n", "").Replace("?=", "");
        
        	return input;
    }

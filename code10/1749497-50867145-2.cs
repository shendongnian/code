    int DecodedLength(string base64)
    {
    	var chars = 0;
    	var padding = 0;
    	for (int i = 0; i < base64.Length; i++)
    	{
    		var ch = base64[i];
    		if (!char.IsWhiteSpace(ch)) { chars++; }
    		if (ch == '=') { padding++; }
    	}
    	return chars / 4 * 3 - padding;
    }
  

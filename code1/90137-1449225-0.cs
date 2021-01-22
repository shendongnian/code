    /// <summary>
    /// Some charcodes produced by unicode character handling
    /// does not map correctly to codepage 1252. This function
    /// translates every char to codepage 1252, unless the char
    /// takes more than one byte. Then it gets encoded using Unicode.
    /// </summary>
    /// <param name="chars"></param>
    /// <returns></returns>
    private string GetStringAfterFixingEncoding(IEnumerable<char> chars)
    {
    	var result = new StringBuilder();
    
    	foreach (var c in chars)
    	{
    		var unicodeBytesForChar = Encoding.Unicode.GetBytes(new[] { c });
    
    		if (unicodeBytesForChar.Length > 1 && unicodeBytesForChar[1] != 0)
    			result.Append(Encoding.Unicode.GetChars(unicodeBytesForChar)[0]);
    		else
    			result.Append(_encoding.GetChars(unicodeBytesForChar)[0]);
    	}
    
    	return result.ToString();
    }

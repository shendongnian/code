    private string RandomPassword(int length, bool includeCharacters, bool includeNumbers, bool includeUppercase, bool includeNonAlphaNumericCharacters, bool includeLookAlikes)
    {
    	if (length < 8 || length > 128) throw new ArgumentOutOfRangeException("length");
    	if (!includeCharacters && !includeNumbers && !includeNonAlphaNumericCharacters) throw new ArgumentException("RandomPassword-Key arguments all false, no values would be returned");
    
    	string pw = "";
    	do
    	{
    		pw += System.Web.Security.Membership.GeneratePassword(128, 25);
    		pw = RemoveCharacters(pw, includeCharacters, includeNumbers, includeUppercase, includeNonAlphaNumericCharacters, includeLookAlikes);
    	} while (pw.Length < length);
    
    	return pw.Substring(0, length);
    }
    
    private string RemoveCharacters(string passwordString, bool includeCharacters, bool includeNumbers, bool includeUppercase, bool includeNonAlphaNumericCharacters, bool includeLookAlikes)
    {
    	if (!includeCharacters)
    	{
    		var remove = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    		foreach (string r in remove)
    		{
    			passwordString = passwordString.Replace(r, string.Empty);
    			passwordString = passwordString.Replace(r.ToUpper(), string.Empty);
    		}
    	}
    
    	if (!includeNumbers)
    	{
    		var remove = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    		foreach (string r in remove)
    			passwordString = passwordString.Replace(r, string.Empty);
    	}
    
    	if (!includeUppercase)
    		passwordString = passwordString.ToLower();
    
    	if (!includeNonAlphaNumericCharacters)
    	{
    		var remove = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "+", "=", "{", "}", "[", "]", "|", "\\", ":", ";", "<", ">", "/", "?", "." };
    		foreach (string r in remove)
    			passwordString = passwordString.Replace(r, string.Empty);
    	}
    
    	if (!includeLookAlikes)
    	{
    		var remove = new string[] { "(", ")", "0", "O", "o", "1", "i", "I", "l", "|", "!", ":", ";" };
    		foreach (string r in remove)
    			passwordString = passwordString.Replace(r, string.Empty);
    	}
    
    	return passwordString;
    }

    bool IsValidFilename(string testName)
    {
    	Regex containsABadCharacter = new Regex("[" 
              + Regex.Escape(System.IO.Path.GetInvalidPathChars()) + "]");
    	if (containsABadCharacter.IsMatch(testName) { return false; };
    
    	// other checks for UNC, drive-path format, etc
    
    	return true;
    }

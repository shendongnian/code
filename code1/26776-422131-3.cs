    bool IsValidFilename(string testName)
    {
        string regexString = "[" + Regex.Escape(Path.GetInvalidPathChars() + "]");
        Regex containsABadCharacter = new Regex(regexString);
        
        if (containsABadCharacter.IsMatch(testName)
        {
            return false;
        }
        // Check for drive
        string pathRoot = Path.GetPathRoot(testName);
        if (Directory.GetLogicalDrives().Contains(pathRoot))
        {
            // etc
        }
        // other checks for UNC, drive-path format, etc
        return true;
    }

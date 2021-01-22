    bool IsValidFilename(string testName)
    {
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(System.IO.Path.InvalidPathChars) + "]");
            if (containsABadCharacter.IsMatch(testName) { return false; };
            //Check for drive
            if(Director.GetLogicalDrives.Contains(Path.GetPathRoot(textName)))
                
  
            // other checks for UNC, drive-path format, etc
            return true;
    }

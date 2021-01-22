    public void FileChecker(string filePath)
    {
        DirectoryInfo di = new DirectoryInfo(filePath);
        int _MatchCounter;
        string RegexPattern = "^[a-zA-Z_a-zA-Z_a-zA-Z_0-9_0-9_0-9.csv]*$";
        Regex RegexPatternMatch = new Regex(RegexPattern, RegexOptions.IgnoreCase);
    
        foreach (FileInfo matchingFile in di.GetFiles())
        {
            Match m = RegexPatternMatch.Match(matchingFile.Name);
    
            if ((m.Success))
            {
                MessageBox.Show(matchingFile.Name);
                _MatchCounter += 1;
            }
        }
    }

    public void foo(string path, string userSearchPattern)
    {
        const string kPattern = "*";
    
        // Interestnigly, using "*" here worked ok.
        string[] dirs = Directory.GetDirectories(path, kPattern, SearchOption.AllDirectories);
        foreach (string subDir in dirs)
        {
            // user search pattern is "*"
            Match m = Regex.Match(subDir, userSearchPattern);
            
            if (m.Success)
            {
                // do something fun here
            }
        }
    }

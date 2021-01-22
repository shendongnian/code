    private List<string> GetFiles(string path, string pattern)
    {
        var files = new List<string>();
    
        try 
        { 
            files.AddRange(Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly));
            foreach (var directory in Directory.GetDirectories(path))
                files.AddRange(GetFiles(directory, pattern));
        } 
        catch (UnauthorizedAccessException) { }
    
        return files;
    }

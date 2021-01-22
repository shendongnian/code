    private void SearchDirectory(DirectoryInfo startDirectory, 
                                 string pattern, 
                                 Action<FileInfo> act)
    {
        foreach (var file in startDirectory.GetFiles(pattern))
            act(file);
        foreach (var directory in startDirectory.GetDirectories())
            SearchDirectory(directory, pattern, act);
    }
    private List<FileInfo> SearchDirectory(DirectoryInfo startDirectory, 
                                           string pattern, 
                                           Func<FileInfo, bool> isWanted)
    {
        var lst = new List<FileInfo>();
        SearchDirectory(startDirectory, 
                        pattern, 
                        (fi) => { if (isWanted(fi)) lst.Add(fi); });
        return lst;
    }

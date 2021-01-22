    private void ConfigureEntry()
    {
        // configure your ad connection to the directory
        _currentDirEntry = new DirectoryEntry(_activeDirectoryRoot, _activeDirectoryUser, _activeDirectoryPW);
    
        DirectorySearch searcher = new DirectorySearcher(_currentDirEntry);
        SearchResult result;
    
        searcher.Filter = "(sAMAccountName=" & _loginName & ")";   // Or whatever criteria you use to get your directoryEntry
        result = searcher.FindOne
    
        if(result == null) return;
        _attributes = result.Properties;
    
        _currentDirEntry = null;
    }
    private StringCollection MemberBelongsToGroups() 
    {
        StringCollection returnCollection = new StringCollection();
    
        foreach(string prop in _attributes("memberOf")) //_attributes is of type System.DirectoryServices.ResultPropertyCollection
        {
            int equalsIndex = prop.IndexOf("=", 1);
            int commaIndex = prop.IndexOf(",", 1);
    
            if(equalsIndex >= 0) returnCollection.Add(prop.SubString((equalsindex + 1), (commaIndex - equalsIndex) - 1));
        }
    
        return returnCollection;
    }

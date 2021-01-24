    public static IReadOnlyList<string> FindDuplicateModFiles(string[] SimsModDownloadDirectory, string[] SimsModsDirectory)
    {
    	var set = new HashSet<string>(SimsModDownloadDirectory);
    	var result = new List<string>();
    	foreach (string file in SimsModsDirectory)
    	{
    		if (set.Contains(file))
    			result.Add(file);
    	}
    	return result.AsReadOnly();
    }

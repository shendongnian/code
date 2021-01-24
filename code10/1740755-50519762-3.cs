    /// <summary>
    /// Searches for files using the pattern defined in 'searchPattern'
    /// Example search patterns: "/project ?/photoshoot ?/flowers ?/*.jpg"
    ///                          "/project ?/plans ?/*.pdf"
    ///                          "/project ?/*.txt"
    /// </summary>
    /// <param name="rootPath">The directory in which to begin the search</param>
    /// <param name="searchPattern">The directory and file search pattern</param>
    /// <returns>A list of file paths that meet the criteria</returns>
    public static List<string> GetDownloadableFiles(string rootPath, string searchPattern)
    {
        if (!Directory.Exists(rootPath)) 
            throw new DirectoryNotFoundException(nameof(rootPath));
        if (searchPattern == null) 
            throw new ArgumentNullException(nameof(searchPattern));
        var files = new List<string>();
        var searchParts = searchPattern.Split(new[] {'/'}, 
            StringSplitOptions.RemoveEmptyEntries);
        // This will hold the list of directories to search, and 
        // will be updated on each iteration of our loop below. 
        // We start with just one item: the 'rootPath'
        var searchFolders = new List<string> {rootPath};
            
        for (int i = 0; i < searchParts.Length; i++)
        {
            var subFolders = new List<string>();
            foreach (var searchFolder in searchFolders)
            {
                // If we're at the last item, it's the file pattern, so add files
                if (i == searchParts.Length - 1)
                {
                    files.AddRange(Directory.GetFiles(searchFolder, searchParts[i]));
                }
                // Otherwise, add the sub directories for this pattern
                else
                {
                    subFolders.AddRange(Directory.GetDirectories(searchFolder, 
                        searchParts[i]));
                }
            }
            // Reset our search folders to use the list from the latest pattern
            searchFolders = subFolders;
        }
        return files;
    }

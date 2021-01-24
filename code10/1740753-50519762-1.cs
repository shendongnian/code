    /// <summary>
    /// Searches for files using the pattern "/folder ?/subfolder ?/*.jpg"
    /// </summary>
    /// <param name="rootPath">The directory in which to begin the search</param>
    /// <returns>A list of file paths that meet the criteria</returns>
    public static List<string> GetDownloadableFiles(string rootPath)
    {
        var files = new List<string>();
        // First find all the directories that match 'folder ?', anywhere under 'rootPath'
        foreach (var directory in Directory.EnumerateDirectories(rootPath, "folder ?", 
            SearchOption.AllDirectories))
        {
            // Now find all directories directly under 'folder ?' named 'subfolder ?'
            foreach (var subDir in Directory.EnumerateDirectories(directory, "subfolder ?"))
            {
                // And add the file path for all '*.jpg' files to our list
                files.AddRange(Directory.GetFiles(subDir, "*.jpg"));
            }
        }
        return files;
    }

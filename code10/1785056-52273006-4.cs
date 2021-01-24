    public static IEnumerable<string> GetAllAccessibleFilesIn(string rootDirectory, string searchPattern = "*.*")
    {
        List<string> files = new List<string>();
        try
        {
            files.AddRange(Directory.GetFiles(rootDirectory, searchPattern, SearchOption.TopDirectoryOnly));
    
            foreach (string directory in Directory.GetDirectories(rootDirectory))
            {
                files.AddRange(GetAllAccessibleFilesIn(directory, searchPattern));
            }
        }
        catch (UnauthorizedAccessException)
        {
            // Don't do anything if we cannot access a file.
        }
        return files;
    }

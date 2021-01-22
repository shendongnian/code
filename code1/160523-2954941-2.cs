    public void DeleteFilesFromDirectory(string directoryPath, string pattern, bool includeSubdirectories)
    {
        string[] files;
        if (!string.IsNullOrEmpty(pattern))
            files = Directory.GetFiles(directoryPath, pattern);
        else
            files = Directory.GetFiles(directoryPath);
        foreach (string file in files)
        {
            File.Delete(file);
        }
        if (includeSubdirectories)
        {
            string[] directories = Directory.GetDirectories(directoryPath);
            foreach (string dir in directories)
                DeleteFilesFromDirectory(dir, pattern, includeSubdirectories);
        }
    }

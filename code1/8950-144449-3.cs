    public static string CreateDirectoryName(string fileName, params string[] folders)
    {
        if(folders == null || folders.Length <= 0)
        {
            return fileName;
        }
        string directory = string.Empty;
        foreach(string folder in folders)
        {
            directory = System.IO.Path.Combine(directory, folder);
        }
        directory = System.IO.Path.Combine(directory, fileName);
        return directory;
    }

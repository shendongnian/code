    public static string CreateDirectoryName(string fileName, params string[] folders)
    {
        StringBuilder directory = new Directory();
        foreach(string s in folders)
        {
            directory.Append(s.Trim(System.IO.Path.GetInvalidPathChars())
            + System.IO.Path.PathSeparator);
        }
        directory.Append(filename.Trim(System.IO.Path.GetInvalidFileNameChars());
        return directory.ToString();
    }

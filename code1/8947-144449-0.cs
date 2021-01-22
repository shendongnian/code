    public static string CreateDirectoryName(string fileName, params string[] folders)
    {
        StringBuilder directory = new Directory();
        foreach(string s in folders)
        {
            directory.Append(s.Trim('\\') + "\\");
        }
        directory.Append(filename);
        return directory.ToString();
    }

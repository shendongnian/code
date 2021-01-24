    public static string FindFile(DirectoryInfo folder, string fileName)
    {
        if (folder.EnumerateFiles().Where(x => x.Name == fileName).ToArray().Length > 0)
        {
            return folder.FullName;
        }
    
        foreach (var newFolder in folder.EnumerateDirectories())
        {
            return FindFile(newFolder, fileName);
        }
    
        return "Nothing found";
    }

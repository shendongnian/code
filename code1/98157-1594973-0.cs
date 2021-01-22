    foreach (FileInfo fi in GetLatestFiles("c:\\test\\", "filename1"))
    {
        Console.WriteLine(fi.Name);
    }
    // ...
    public static IEnumerable<FileInfo> GetLatestFiles(string path, string baseName)
    {
        return new DirectoryInfo(path)
            .GetFiles(baseName + "*.*")
            .GroupBy(f => f.Extension)
            .Select(g => g.OrderByDescending(f => f.LastWriteTime).First());
    }

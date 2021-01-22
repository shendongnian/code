    public static string[] GetGlobalAssemblyCacheFiles(string path)
    {
        List<string> files = new List<string>();
        DirectoryInfo di = new DirectoryInfo(path);
        foreach (FileInfo fi in di.GetFiles("*.dll"))
        {
            files.Add(fi.FullName);
        }
        foreach (DirectoryInfo diChild in di.GetDirectories())
        {
            var files2 = GetGlobalAssemblyCacheFiles(diChild.FullName);
            files.AddRange(files2);
        }
        return files.ToArray();
    }

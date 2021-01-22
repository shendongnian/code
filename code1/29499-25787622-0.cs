    public static long GetDirSize(string path)
    {
        try
        {
            return Directory.EnumerateFiles(path).Sum(x => new FileInfo(x).Length)  
                +
                   Directory.EnumerateDirectories(path).Sum(x => GetDirSize(x));
        }
        catch
        {
            return 0L;
        }
    }

    static void Main()
    {
        string uploadDirectory = "c:\\some\\path\\";
        if (Directory.Exists(uploadDirectory))
        {
            var files = from filename in Directory.GetFiles(uploadDirectory)
                      where File.GetLastWriteTime(filename) < DateTime.Now.AddHours(-12)
                      select filename;
            files.ForEach(File.Delete);            
        }
    }
    static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
    {
        foreach (T item in items)
        {
            action(item);
        }
    }

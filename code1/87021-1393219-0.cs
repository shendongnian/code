    // using System.Linq
    private static void AddFiles(string path, IList<string> files)
    {
        try
        {
            Directory.GetFiles(path)
                .ToList()
                .ForEach(s => files.Add(s));
    
            Directory.GetDirectories(path)
                .ToList()
                .ForEach(s => AddFiles(s, files));
        }
        catch (UnauthorizedAccessException ex)
        {
            // ok, so we are not allowed to dig into that directory. Move on.
        }
    }

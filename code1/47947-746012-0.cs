    private static string getRandomFile(string path)
    {
        try
        {
            var extensions = new string[] { ".png", ".jpg", ".gif" };
            var di = new DirectoryInfo(path);
            return (di.GetFiles("*.*")
                                .Where(f => extensions.Contains(f.Extension
                                                                   .ToLower()))
                                .OrderBy(f => Guid.NewGuid())
                                .First()).FullName ;              
        }
        catch { return ""; }
    }

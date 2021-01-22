    public static bool IsTextFileEmpty(string fileName)
    {
        var info = new FileInfo(fileName);
        if (info.Length == 0)
            return true;
    
        // only if your use case can involve files with 1 or a few bytes of content.
        if (info.Length < 6)
        {
            var content = File.ReadAllText(fileName);   
            return content.Length == 0;
        }
        return false;
    }

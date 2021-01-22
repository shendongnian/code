    static void Main(string[] args)
    {
        var match = FindMatch(args[0]);
        Console.WriteLine("Best match for {0} is {1}", args[0], match ?? "[None found]");
    }
    
    private static string FindMatch(string pathAndFilename)
    {
        return FindMatch(Path.GetDirectoryName(pathAndFilename), Path.GetFileNameWithoutExtension(pathAndFilename));
    }
    
    private static string FindMatch(string path, string filename)
    {
        return Directory.GetFiles(path, filename + ".*").FirstOrDefault();
    }

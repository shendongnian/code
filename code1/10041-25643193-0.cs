    public static List<string> GetFilez(string path, System.IO.SearchOption opt,  params string[] patterns)
    {
        List<string> filez = new List<string>();
        foreach (string pattern in patterns)
        {
            filez.AddRange(
                System.IO.Directory.GetFiles(path, pattern, opt)
            );
        }
        // filez.Sort(); // Optional
        return filez; // Optional: .ToArray()
    }

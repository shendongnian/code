    private static List<string> GetDirectories(string path, int level, string searchPattern = "*")
    {
        if (level == 0)
            return Directory.GetDirectories(path, searchPattern, SearchOption.TopDirectoryOnly).ToList();
        else
        {
            List<string> l = new List<string>();
            foreach (string path2 in Directory.GetDirectories(path, searchPattern, SearchOption.TopDirectoryOnly))
                l.AddRange(GetDirectories(path2, level - 1, searchPattern));
            return l;
        }
    }

    static string[] SplitLDAPPath(string input)
    {
        List<String> r = new List<string>();
        string[] split = input.Split(',');
        string path = "";
        for (int i = split.Length - 1; i >= 0; i--)
        {
            path = split[i] + "," + path;
            if (path.StartsWith("OU"))
                r.Add(path.Substring(0, path.Length-1));
        }
        return r.ToArray();
    }

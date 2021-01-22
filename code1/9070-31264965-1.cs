    private static string CleanPath(string path)
    {
        string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
        Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
        List<string> split = path.Split('\\').ToList();
        string returnValue = split.Aggregate(string.Empty, (current, s) => current + (r.Replace(s, "") + @"\"));
        returnValue = returnValue.TrimEnd('\\');
        return returnValue;
    }

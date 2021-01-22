    internal static List<string> Split(this DirectoryInfo path)
    {
        if(path == null) throw new ArgumentNullException("path");
        var ret = new List<string>();
        if (path.Parent != null) ret.AddRange(Split(path.Parent));
        ret.Add(path.Name);
        return ret;
    }

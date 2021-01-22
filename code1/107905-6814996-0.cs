    static public bool SameDirectory(string path1, string path2)
    {
        return (
            0 == String.Compare(
                System.IO.Path.GetFullPath(path1).TrimEnd('\\'),
                System.IO.Path.GetFullPath(path2).TrimEnd('\\'),
                StringComparison.InvariantCultureIgnoreCase))
            ;
    }    

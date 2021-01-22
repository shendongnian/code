    private static List<DirectoryInfo> SplitDirectory(DirectoryInfo parent)
    {
        if (parent == null) return null;
        var rtn = new List<DirectoryInfo>();
        var di = parent;
    
        while (di.Name != di.Root.Name)
        {
    	rtn.Add(new DirectoryInfo(di));
    	di = di.Parent;
        }
        rtn.Add(new DirectoryInfo(di.Root));
    
        rtn.Reverse();
        return rtn;
    }
 

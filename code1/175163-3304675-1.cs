    [SecuritySafeCritical]
    public static StreamWriter CreateText(string path)
    {
        if (path == null)
        {
            throw new ArgumentNullException("path");
        }
        return new StreamWriter(path, false);  // append=false is the default anyway
    }
    

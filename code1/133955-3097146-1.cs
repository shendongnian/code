    public static string findFileDirectory(string file)
    {
        // Get the directory where our service is being run from
        string temppath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        // Ensure proper path notation so we can add the INI file name
        if (!temppath.EndsWith(@"\")) temppath += @"\";
    
        return temppath;
    }

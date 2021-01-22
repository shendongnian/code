    public static string GetApplicationRoot()
    {
       var exePath = new Uri(System.Reflection.
       Assembly.GetExecutingAssembly().CodeBase).LocalPath;
       return new FileInfo(exePath).DirectoryName;
           
    }

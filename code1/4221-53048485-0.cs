    public static string AssemblyDirectory
    {
        get
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            //modification of the John Sibly answer    
            string path = Uri.UnescapeDataString(uri.Path.Replace("/", "\\") + 
              uri.Fragment.Replace("/", "\\"));
            return Path.GetDirectoryName(path);
         }
    }
    

    // List of all the different types of GAC folders for both 32bit and 64bit
    // environments.
    List<string> gacFolders = new List<string>() { 
        "GAC", "GAC_32", "GAC_64", "GAC_MSIL", 
        "NativeImages_v2.0.50727_32", 
        "NativeImages_v2.0.50727_64" 
    };
    
    foreach (string folder in gacFolders)
    {
        string path = Path.Combine(Environment.ExpandEnvironmentVariables(@"%systemroot%\assembly"), folder);
        if(Directory.Exists(path))
        {
            Response.Write("<hr/>" + folder + "<hr/>");
    
            string[] assemblyFolders = Directory.GetDirectories(path);
            foreach (string assemblyFolder in assemblyFolders)
            {
                Response.Write(assemblyFolder + "<br/>");
            }
        }
    }

    string[] extensions = {"*.jpg" , "*.png" };
    
    List<string> files = new List<string>();
    foreach(string filter in extensions)
    {
        files.AddRange(System.IO.Directory.GetFiles(path, filter));
    }
    foreach (string s in files)
    {
        oList.Add( System.IO.Path.GetFileName( s ));
    }

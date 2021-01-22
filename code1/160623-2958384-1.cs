    String strPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
    
    XDocument doc = XDocument.Load(strPath);
        
    foreach (XElement element in doc.Root.Nodes())
    {
        // do stuff
    }

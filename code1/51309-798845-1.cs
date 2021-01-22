    public void LoadRulesFromXml( string in_xmlFileName, string in_type ) 
    {   
        // To see what's going on
        Debug.WriteLine("Current directory is " +
                  System.Environment.CurrentDirectory);    
    
        XmlDocument xmlDoc = new XmlDocument();    
    
        // Use an explicit path
        xmlDoc.Load( 
           System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
           in_xmlFileName) 
        );
    ...

    private string GetHtmlString()
    {
        DirectoryInfo di = new DirectoryInfo("some directory");
        FileInfo[] files = di.GetFiles("*.dll", SearchOption.AllDirectories);
                
        var container = new XElement("div",
            from file in files
            let assembly = Assembly.LoadFile(file.FullName)
            select new XElement("p", assembly.GetName().Version.ToString())
        );
        
        return container.ToString();
     }

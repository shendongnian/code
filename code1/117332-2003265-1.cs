    private string GetHtmlString()
    {
        DirectoryInfo di = new DirectoryInfo("some directory");
        FileInfo[] files = di.GetFiles("*.dll", SearchOption.AllDirectories);
        var container = new XElement("table",
            from file in files
            let assembly = Assembly.LoadFile(file.FullName)
            select new XElement("tr", 
                new XElement("td", file.FullName),
                new XElement("td", assembly.GetName().Version.ToString())
            )
        );
        return container.ToString();
     }

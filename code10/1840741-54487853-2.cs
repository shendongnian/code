    private SqlConnectionStringBuilder BuilderFromElement(XElement source)
    {
        return new SqlConnectionStringBuilder
        {
            DataSource = source.Attribute("Server")?.Value,
            InitialCatalog = source.Attribute("Database")?.Value,
            UserID = source.Attribute("UserID")?.Value,
            Password = source.Attribute("Password")?.Value
        };
    }
    private string GetConnectionString()
    {
        var settings = XDocument.Load("Settings.xml");
        var allConnectionStrings = 
            settings.Descendants("DataSource")
                    .Select(BuilderFromElement)
                    .Select(builder => builder.ConnectionString)
                    
        return allConnectionStrings.FirstOrDefault();
    }

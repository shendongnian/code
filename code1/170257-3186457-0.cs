    public class UpdateConnectionString : Task
        {
            [Required]
            public string ConfigFile { get; set; }
            [Required]
            public string ConnectionStringName { get; set; }
            [Required]
            public string ConnectionString { get; set; }
    
            public override bool Execute()
            {
                try
                {
                    var fi = new FileInfo(ConfigFile);
                    if(!fi.Exists)
                    {
                        Log.LogError("File {0} does not exist");
                        return false;
                    }
                    fi.IsReadOnly = false;
                    XDocument doc = XDocument.Load(ConfigFile);
                    var confignode = doc.Descendants("configuration").Single();
                    var connectionStrings = confignode.Descendants("connectionStrings").SingleOrDefault();
                    if(connectionStrings == null)
                    {
                        connectionStrings = new XElement("connectionStrings");
                        confignode.Add(connectionStrings);
                    }
                    var connectionElement = connectionStrings.Descendants("add").SingleOrDefault(
                        e => e.Attribute("name") != null &&
                             string.Compare(e.Attribute("name").Value, ConnectionStringName,
                                            StringComparison.OrdinalIgnoreCase) == 0);
                    if (connectionElement == null)
                    {
                        connectionElement = new XElement("add", new XAttribute("name", ConnectionStringName));
                        connectionStrings.Add(connectionElement);
                    }
                    
                    connectionElement.SetAttributeValue("connectionString", ConnectionString);
                    doc.Save(ConfigFile);
                }
                catch (Exception ex)
                {
                    Log.LogErrorFromException(ex, true);
                    return false;
                }   
                return true;
            }
        }

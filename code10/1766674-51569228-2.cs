    public static string XMLCheck
    {
        get
        {
            var section = (XmlElement)ConfigurationManager.GetSection("Default.Framework");
            var connectionString = section.SelectSingleNode(@"
                descendant::Resource[@Uri='resource:Default:CrossDomain']
                /Properties
                /Property[@Name='ConnectionString']
                /@Value");
            return connectionString.Value;
        }
    }

    public override void Install(IDictionary stateSaver)
    {
        base.Install(stateSaver);
    
        string server = Context.Parameters["Server"];
        string port = Context.Parameters["Port"];
        string targetDir = Context.Parameters["TargetDir"];
    
        WriteAppConfig(targetDir, server, port);
    }
    
    private void WriteAppConfig(string targetDir, string server, string port)
    {
        string configFilePath = Path.Combine(targetDir, "User.config");
    
        IDictionary<string, string> userConfiguration = new Dictionary<string, string>();
    
        userConfiguration["Server"] = server;
        userConfiguration["Port"] = port;
    
        ConfigGenerator.WriteExternalAppConfig(configFilePath, userConfiguration);
    }
    
    public class ConfigGenerator
    {
        public static void WriteExternalAppConfig(string configFilePath, IDictionary<string, string> userConfiguration)
        {
            using (XmlTextWriter xw = new XmlTextWriter(configFilePath, Encoding.UTF8))
            {
                xw.Formatting = Formatting.Indented;
                xw.Indentation = 4;
                xw.WriteStartDocument();
                xw.WriteStartElement("appSettings");
    
                foreach (KeyValuePair<string, string> pair in userConfiguration)
                {
                    xw.WriteStartElement("add");
                    xw.WriteAttributeString("key", pair.Key);
                    xw.WriteAttributeString("value", pair.Value);
                    xw.WriteEndElement();
                }
    
                xw.WriteEndElement();
                xw.WriteEndDocument();
            }
        }
    }
    

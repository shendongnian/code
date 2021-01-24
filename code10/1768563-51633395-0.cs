    public void WriteSettings(TextWriter writer) 
    {
        // Declare the nameSpace for the DLL you want to pull settings from
        var nameSpace = "foo.Bar"
        ApplicationSettingsBase properties = (System.Configuration.ApplicationSettingsBase)Activator.CreateInstance(nameSpace, string.Format("{0}.Properties.Settings", nameSpace)).Unwrap();
        foreach (SettingsProperty property in properties.Properties) 
        {
            writer.Write(string.Format("{0}=\"{1}\", property.Name, properties[property.Name]);
        }
    }

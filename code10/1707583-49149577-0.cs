    if ((name != null) && (name.Any())
    {
        foreach(string thisName in name)
        {
            if (thisName.Contains(ConfigurationManager.AppSettings
                .Get("Name"),StringComparison.OrdinalIgnoreCase)))
            {
                   //do something
            }
        }
    }

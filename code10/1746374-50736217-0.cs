    public void RegisterURLProtocol(string protocolName, string applicationPath, string description)
    {
        // Create new Key for URL Protocol
        RegistryKey myKey=Registry.ClassesRoot.CreateSubKey(protocolName);
        
        // Assign Protocol
        myKey.SetValue(null, description);
        myKey.SetValue("URL Protocol", string.Empty);
        
        // Assign Shell Values
        Registry.ClassesRoot.CreateSubKey(protocolName + "\\Shell");
        Registry.ClassesRoot.CreateSubKey(protocolName + "\\Shell\\open");
        myKey = Registry.ClassesRoot.CreateSubKey(protocolName + "\\Shell\\open\\command");
        
        // Determine App who's receiving the URL calls with params
        myKey.SetValue(null, "\"" + applicationPath,  + "\" %1");
    }

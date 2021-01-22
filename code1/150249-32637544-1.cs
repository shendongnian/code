    // This casts to a NameValueCollection because the section is defined as a 
    /// AppSettingsSection in the configSections.
    NameValueCollection settingCollection = 
        (NameValueCollection)ConfigurationManager.GetSection("YourAppSettings");
    var items = settingCollection.Count;
    Debug.Assert(items == 4); // no duplicates... the last one wins.
    Debug.Assert(settingCollection["duplicate"] == "bb");
    // Just keys as per original question? done... use em.
    string[] allKeys = settingCollection.AllKeys;
    
    // maybe you did want key/value pairs. This is flexible to accommodate both.
    foreach (string key in allKeys)
    {
        Console.WriteLine(key + " : " + settingCollection[key]);
    }

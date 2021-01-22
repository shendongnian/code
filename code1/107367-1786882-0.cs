    Dictionary<string, Dictionary<string, string>> deviceAttributes = new 
       Dictionary<string, Dictionary<string, string>>();
    
    void AddAttribute(string deviceIdentifier, string attribute, string value)
    {
       if(!deviceAttributes.Keys.Contains(deviceIdentifier))
          deviceAttributes.Add(deviceIdentifier, new Dictionary(attribute, value);
       else
          deviceAttributes[deviceIdentifier].Add(attribute, value);
    }
    

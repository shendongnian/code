    // Load settings into XDocument settingsXML
    // Load updates into XDocument updatesXML
    
    // Loop through the updates
    foreach(XElement update in updatesXML.Element("preset").Elements("var"))
    {
        // Find the element to update
        XElement settingsElement = (from s in settingsXML.Element("preset").Elements("var")
                              where s.Attribute("id").Value == update.Attribute.Value("id") &&
                                    s.Attribute("opt").Value == update.Attribute.Value("opt")
                              select s).FirstOrDefault();
    
        if (settingsElement != null)
        {
          settingsElement.Attribute("val").Value = update.Attribute("val").Value;
        }
        else
        {
          // not found handling
        }
    }
    
    // Save settingsXML document 

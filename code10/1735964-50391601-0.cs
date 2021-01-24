    // Gets your config section. It won't parse the xml to a 
    // key/value structure, but does provide the raw xml
    var b = config.GetSection("AutoUpdate/Settings"); 
            
    var rawXml = b.SectionInformation.GetRawXml();
    
    // Get the raw xml value and load it to a queryable XDocument object
    var doc = XDocument.Parse(rawXml);
    doc.Descendants("add")
        .Single(x => x.Attribute("key").Value == "ServerUrl")
        .SetAttributeValue("value", "http://newthing.xml");
    // Set the new xml back to the configuration object and persist the changes
    b.SectionInformation.SetRawXml(doc.ToString());
    config.Save(ConfigurationSaveMode.Modified, true);

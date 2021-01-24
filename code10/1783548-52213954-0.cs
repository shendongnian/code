    XDocument doc = new XDocument(new XElement("Set"));
    while (reader.Read()) {
        var setting = new XElement("Setting", "the name"); 
        setting.Add(new XAttribute("empID", "the id"));
        doc.Root.Add(setting);
    }

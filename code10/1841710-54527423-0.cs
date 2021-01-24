    XElement doc = XElement.Parse(xml);
    
    var result = doc.Element("para")
                     .Elements("r").Elements("u")
                     .Select(item => item.Element("v"));
    foreach (XElement item in result)
    {
    	
        item.SetValue("New Value");
    }
    var newXml = doc.ToString();

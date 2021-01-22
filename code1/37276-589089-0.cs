    XDocument xDoc = XDocument.Load("FILENAME.xml");
    
    // assuming you types is the parent and mytype is a bunch of nodes underneath
    IEnumerable<XElement> elements = xdoc.Element("types").Elements("myType");
    
    foreach (XElement type in elements)
    {
        // option 1
        type.Attribute("id").Value = NEWVALUE;
        // option 2
        type.SetAttributeValue("id", NEWVALUE);
    }

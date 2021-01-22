    XmlDocument doc = new XmlDocument();
    doc.Load("D:\\schema.xsd");                      // Load the document from the root of an ASP.Net website
    XmlElement schemaElement = doc.DocumentElement;  // The root element of the schema document is the <schema> element
    string elementName = schemaElement.LocalName;    // This will print "schema"
    foreach (XmlNode ele in schemaElement.ChildNodes)
    {
        if (ele.LocalName == "element")
        {
            // This is a valid root node
            // Note that there will be *more than one* of these if you have multiple elements declare at the base level
        }
    }

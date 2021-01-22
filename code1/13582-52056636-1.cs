    XmlDocument MyXmlDocument = new XmlDocument();
    MyXmlDocument.Load("MyXml.xml");
    XElement MyXElement = MyXmlDocument.GetXElement(); // Convert XmlNode to XElement
    List<XElement> List = MyXElement.Document
       .Descendants()
       .ToList(); // Now you can use LINQ
    ...

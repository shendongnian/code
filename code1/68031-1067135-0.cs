    XDocument doc = XDocument.Parse(@"..."); 
    
    var children = doc.Elements().Single().Elements().OrderBy(element => (string) element.Attribute("Name"));
    
    var newRoot = new XElement(((XNamespace) "yourNamespaceHere") + "Fields",
     new XAttribute(XNamespace.Xmlns + "nso", "yourNamespaceHere"),
     new XAttribute(XNamespace.Xmlns + "omm", "otherNamespace"),
     children);
    
    var newDocument = new XDocument(newRoot);
    Console.WriteLine(newDocument); 

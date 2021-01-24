    int[] invoice = new int[] {1002,1003};
    List<XElement> eleList = new List<XElement>();
    
    foreach (int i in invoice)
    {
      eleList.Add(
                new XElement("Invoice",
                new XElement("Field",
                  new XAttribute("name","CustomerNo"),
                  new XAttribute("value","10000")),
                new XElement("Field",
                  new XAttribute("name","Email"),
                  new XAttribute("value","testemail@yahoo.com")),
                new XElement("Field",
                  new XAttribute("name","Invoice"),
                  new XAttribute("value",i)))
       );
    }
    
    XDocument xDocument = new XDocument(
        new XDeclaration("1.0", "UTF-8", null),
          new XElement("Request",
            new XElement("Operation", "Testing"),
            new XElement("Count","2"),                               
            new XElement("Params", eleList)));

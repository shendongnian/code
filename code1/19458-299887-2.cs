    string xmlInput = //...
    XDocument myDoc = XDocument.Parse(xmlInput);
    //
    List<XText> someText =
      myDoc.Descendants()
      .Nodes()
      .OfType<XText>()
      .Where(x => x.Value.StartsWith("{") && x.Value.EndsWith("}"))
      .ToList();
    //
    List<XAttribute> someAttributes =
      myDoc.Descendants()
      .Attributes()
      .Where(x => x.Value.StartsWith("{") && x.Value.EndsWith("}"))
      .ToList();
    //
    someElements.ForEach(x => x.Value = "Foo");
    someAttributes.ForEach(x => x.Value = "Bar");
    //
    Console.WriteLine(myDoc);

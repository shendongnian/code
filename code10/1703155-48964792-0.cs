    var xmlDoc = XDocument.Load("YourFile.xml");
    var result = xmlDoc.Descendants("{DAV:}classschema")
        .Where(x => x.Elements().First().Value == "File")
        .Attributes("name")
        .Select(x => x.Value);
    string spaceDelimited = string.Join(" ", result);

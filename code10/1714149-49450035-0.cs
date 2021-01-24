    var xml = XDocument.Parse(xmlString);
    // a, b
    string[] matchingNames = xml.Root.Elements("group")
        .Where(g => g.Elements("ip").Any(e => e.Value == textBoxText))
        .Select(g => g.Attribute("name").Value).ToArray();

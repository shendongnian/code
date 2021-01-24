    XDocument xDoc = XDocument.Parse(str);
    List<XElement> allChildNodes = new List<XElement>();
    foreach (var parent in xDoc.Root.Elements("Parent"))
    {
        allChildNodes.AddRange(parent.Descendants());
    }
    XElement xParent = new XElement("Parent");
    xParent.Add(allChildNodes);
    xDoc.Root.Descendants().Remove();
    xDoc.Root.Add(xParent);

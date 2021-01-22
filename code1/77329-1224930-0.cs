    XNamespace ns = XNamespace.Get("http://www.w3.org/2005/Atom");
...
    from entry in xDoc.Descendants(ns + "entry")
    select new
    {
        Id = entry.Element(ns + "id").Value,
        Categories = entry.Elements(ns + "category").Select(c => c.Value)
        ...
    };

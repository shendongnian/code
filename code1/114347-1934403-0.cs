    public XElement GetHeroIcon(string name)
    {
        XDocument doc = XDocument.Load(path);
        return doc.Descendants(name).Single();
    }

    public string ExtractNodeValue(XDocument doc, string search)
    {
        var result = doc.Descendants("entry")
                        .Where(x => x.Elements().ElementAt(0).Value == search)
                        .Select(i => (string)i.Elements().ElementAt(1).Value)
                        .FirstOrDefault();
    
        return result;
    }

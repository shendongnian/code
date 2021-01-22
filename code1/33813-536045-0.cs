    static string CategoryValue(this XElement element, string type)
    {
        var category = element.Elements("category").SingleOrDefault(
            c => (string)c.Attribute("type") == type);
        return category == null ? null : category.Value;
    }
    static void Main()
    {
        XDocument doc = XDocument.Parse(xml);
        var qry = from item in doc.Descendants("item")
                  where item.CategoryValue("Channel") == "Automotive"
                  && item.CategoryValue("Type") == "Cars"
                  select item;
        foreach (var node in qry)
        {
            Console.WriteLine(node.Element("guid").Value);
        }
    }

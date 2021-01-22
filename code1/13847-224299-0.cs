    static void Main(string[] args)
    {
        XDocument doc = new XDocument(
            new XElement("root",
                new XElement("one", 1),
                new XElement("two", 2)
                ));
        var results = from XElement el in doc.Element("root").Descendants()
                      orderby el.Value descending
                      select el;
        foreach (var item in results)
            Console.WriteLine(item);
        doc.Root.ReplaceAll( results.ToArray());
        Console.WriteLine(doc);
        Console.ReadKey();
    }

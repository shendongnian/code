       XDocument doc= XDocument.Parse("<poi><city>stockholm</city><country>sweden</country><gpoint><lat>51.1</lat><lng>67.98</lng></gpoint></poi>");
        var points=doc.Descendants(XName.Get("gpoint"));
        foreach (XElement current in points)
        {
            Console.WriteLine(current.Element(XName.Get("lat")).Value);
            Console.WriteLine(current.Element(XName.Get("lng")).Value);
        }
        Console.ReadKey(); 

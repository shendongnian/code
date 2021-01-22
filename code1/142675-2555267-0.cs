    XDocument document = XDocument.Parse(xml); // xml string
    var query = from file in document.Descendants("file")
                select new
                    {
                        Monitored = (int)file.Element("monitored"),
                        Name = (string)file.Element("name"),
                        Size = (int)file.Element("size")
                    };
    
    foreach (var file in query)
    {
        Console.WriteLine("{0}\t{1}", file.Name, file.Size);
    }

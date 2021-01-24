    List<String> values = new List<string>();
    using (var xmlreader = XmlReader.Create("test.xml"))
    {
        xmlreader.ReadToDescendant("Section");
        while (xmlreader.Read())
        {
            if (xmlreader.IsStartElement())
            {
                values.Add(xmlreader.GetAttribute("Name"));
            }
        }
    }

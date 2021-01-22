    var nodeCount = 0;
    using (var reader = XmlReader.Create("test.xml"))
    {
        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && 
                reader.Name == "submenuid")
            {
                nodeCount++;
            }
        }
    }
    Console.WriteLine(nodeCount);

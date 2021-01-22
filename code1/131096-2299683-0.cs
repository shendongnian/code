    while (!xmlReader.EOF)
    {
        Console.WriteLine(xmlReader.NodeType);
        if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "bar")
        {
            var element = xmlReader.ReadOuterXml();
            Console.WriteLine("just got an " + element);
            count++;                
        }
        else
        {
            xmlReader.Read();
        }
    }

    while (reader.Read())
    {
        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "price"))
        {
            Console.WriteLine(reader.ReadInnerXml());
            break;
        }
    }

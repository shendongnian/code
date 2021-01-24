    while (reader.Read())
    {
        if (reader.NodeType == XmlNodeType.Element &&  reader.Name == "product")
        {                   
            var productElement = XElement.ReadFrom(reader);
            // use element
            string productName = productElement.Element("name").Value;
        }
    }

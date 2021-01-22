    using (var reader = XmlReader.Create("data.xml"))
    {
        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Item")
            {
                string value = reader.ReadElementContentAsString();
                if (value == "ValueToFind")
                {
                    // value found
                    break;
                }
            }
        }
    }

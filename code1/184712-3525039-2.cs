    public override void ReadXml(XmlReader reader)
    {
        reader.MoveToContent();
        bool isEmptyElement = reader.IsEmptyElement;
        reader.ReadStartElement();
        if (isEmptyElement)
        {
            return;
        }
        while (XmlNodeType.EndElement != reader.NodeType)
        {
            // Bypass XmlNodeType.Whitespace, as found in XML files
            while (XmlNodeType.Element != reader.NodeType)
            {
                if (XmlNodeType.EndElement == reader.NodeType)
                {
                    reader.ReadEndElement();
                    return;
                }
                reader.Read();
            }
            string key = reader.Name;
            if (keyIsSubTree(key))
            {
                storeSubtree(key, reader.ReadSubtree());
            }
            else
            {
                string value = reader.ReadElementString();
                storeKeyValuePair(key, value ?? string.Empty);
            }
        }
        if (XmlNodeType.EndElement == reader.NodeType)
        {
            reader.ReadEndElement();
        }
    }

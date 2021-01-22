    public override void ReadXml(XmlReader reader)
    {
        reader.MoveToContent();
        bool isEmptyElement = reader.IsEmptyElement;
        reader.ReadStartElement();
        if (!isEmptyElement)
        {
            while (XmlNodeType.Element == reader.NodeType)
            {
                string key = reader.Name;
                string value = reader.ReadElementString();
                this[key] = value;
            }
            reader.ReadEndElement();
        }
    }

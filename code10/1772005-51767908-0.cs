    string FindXmlEncoding(string path)
    {
        XmlTextReader reader = new XmlTextReader(path);
        reader.Read();
        if (reader.NodeType == XmlNodeType.XmlDeclaration)
        {
            while (reader.MoveToNextAttribute())
            {
                if (reader.Name == "encoding")
                    return reader.Value;
            }
        }
        return null;
    }

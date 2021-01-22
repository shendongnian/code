    using (StringReader strReader = new StringReader(yourXMLString))
    {
        using (XmlReader reader = XmlReader.Create(strReader))
        {
            while (reader.Read())
            {
                if(reader.Name == "Table" && reader.NodeType == reader.NodeType == XmlNodeType.Element)
                {
                    using(XmlReader tableReader = reader.ReadSubtree())
                    {
                        ReadTableNode(tableReader);
                    }
                }
            }
        }
    }
    private void ReadTableNode(XmlReader reader)
    {
        while (reader.Read())
        {
            if(reader.Name == "ID" && reader.NodeType == reader.NodeType == XmlNodeType.Element)
                //do something
            else if(reader.Name == "CAT" && reader.NodeType == reader.NodeType == XmlNodeType.Element)
                //do something
    
           //and continue....
        }
    }

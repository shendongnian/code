    string xmlcontent = "<BigXml/>";
    
    using(StringReader strContent = new StringReader(xmlcontent))
    {
        using (XmlReader reader = XmlReader.Create(strContent))
        {
            while (reader.Read())
            {
                if (reader.Name == "SomeName" && reader.NodeType == XmlNodeType.Element)
                {
                    //Send the XmlReader created by ReadSubTree to a function to read it.
                    ReadSubContentOfSomeName(reader.ReadSubtree());
                }
            }
        }
    }

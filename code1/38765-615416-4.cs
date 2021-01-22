    System.Xml.XmlTextReader textReader = new System.Xml.XmlTextReader("testin.xml");
    textReader.EntityHandling = System.Xml.EntityHandling.ExpandEntities;
    System.Xml.XmlTextWriter textWriter = new System.Xml.XmlTextWriter("testout.html", System.Text.Encoding.UTF8);
    while (textReader.Read())
    {
        if (textReader.NodeType != System.Xml.XmlNodeType.DocumentType)
            textWriter.WriteNode(textReader, false);
        else
            textReader.Skip();
    }
    textWriter.Close();

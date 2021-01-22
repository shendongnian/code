    HttpWebRequest req;
    try
    {
        req = (HttpWebRequest)WebRequest.Create("http://www.example.com");
        Stream stream = req.GetResponseStream();
        XmlTextReader reader = new XmlTextReader(stream);
        while (reader.Read())
        {
           switch (reader.NodeType) 
            {
             case XmlNodeType.Element:
               Console.Write("<{0}>", reader.Name);
               break;
             case XmlNodeType.Text:
               Console.Write(reader.Value);
               break;
             case XmlNodeType.CDATA:
               Console.Write("<![CDATA[{0}]]>", reader.Value);
               break;
             case XmlNodeType.ProcessingInstruction:
               Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
               break;
             case XmlNodeType.Comment:
               Console.Write("<!--{0}-->", reader.Value);
               break;
             case XmlNodeType.XmlDeclaration:
               Console.Write("<?xml version='1.0'?>");
               break;
             case XmlNodeType.Document:
               break;
             case XmlNodeType.DocumentType:
               Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
               break;
             case XmlNodeType.EntityReference:
               Console.Write(reader.Name);
               break;
             case XmlNodeType.EndElement:
               Console.Write("</{0}>", reader.Name);
               break;
           }       
            
        }       
    }
    finally
    {
        if (req != null)
            req.Close();
    }

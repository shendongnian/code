    System.Xml.XmlDocument orgDoc = new System.Xml.XmlDocument();
    orgDoc.LoadXml(orgXML);
    
    // MUST SELECT THE ROOT NODE
    XmlNode transNode = orgDoc.SelectSingleNode("/");
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    XmlWriter writer = XmlWriter.Create(sb);
    
    System.IO.StringReader stream = new System.IO.StringReader(transformXML);
    XmlReader reader = XmlReader.Create(stream);
    
    System.Xml.Xsl.XslCompiledTransform trans = new System.Xml.Xsl.XslCompiledTransform();
    trans.Load(reader);
    trans.Transform(transNode, writer);
    
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(sb.ToString());
    
    return doc;

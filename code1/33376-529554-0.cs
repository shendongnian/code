    public static string TransformXMLDocFromFileHTMLString(string orgXML, string transformFilePath)
    {
        System.Xml.XmlDocument orgDoc = new System.Xml.XmlDocument();
        orgDoc.LoadXml(orgXML);
    
        XmlNode transNode = orgDoc.SelectSingleNode("/");
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        XmlWriterSettings settings = new XmlWriterSettings();
        
        settings.ConformanceLevel = ConformanceLevel.Auto;
        XmlWriter writer = XmlWriter.Create(sb, settings);
    
        System.Xml.Xsl.XslCompiledTransform trans = new System.Xml.Xsl.XslCompiledTransform();
        trans.Load(transformFilePath);
    
        trans.Transform(transNode, writer);
    
        return sb.ToString();
    }

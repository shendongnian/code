    public RdlReader OpenXml(string xml)
    {
        System.Xml.XmlDocument document = new System.Xml.XmlDocument();
        document.XmlResolver = null;
        document.PreserveWhitespace = true;
        document.LoadXml(xml);
        string default_namespace = Xml2CSharp.Report.DEFAULT_NAMESPACE;
        string designer_namespace = Xml2CSharp.Report.DESIGNER_NAMESPACE;
        if (document.DocumentElement.HasAttribute("xmlns"))
            default_namespace = document.DocumentElement.Attributes["xmlns"].Value;
        if (document.DocumentElement.HasAttribute("xmlns:rd"))
            designer_namespace = document.DocumentElement.Attributes["xmlns:rd"].Value;
        this.m_xml = xml
            .Replace(default_namespace, Xml2CSharp.Report.DEFAULT_NAMESPACE)
            .Replace(designer_namespace, Xml2CSharp.Report.DESIGNER_NAMESPACE);
        document = null;
        document = new System.Xml.XmlDocument();
        document.XmlResolver = null;
        document.PreserveWhitespace = true;
        document.LoadXml(this.m_xml);
        Xml2CSharp.Report rep = Tools.XML.Serialization.DeserializeXmlFromString<Xml2CSharp.Report>(this.m_xml);
        System.Console.WriteLine(rep);
        this.m_document = document;
        this.m_nsmgr = GetReportNamespaceManager(this.m_document);
        
        return this;
    }

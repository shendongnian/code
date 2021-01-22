    public static bool IsValidXhtml(this string text)
    {
       bool errored = false;
       var reader = new XmlValidatingReader(text, XmlNodeType.Element, new XmlParserContext(null, new XmlNamespaceManager(new NameTable()), null, XmlSpace.None));
       reader.ValidationEventHandler += ((sender, e) => { errored = e.Severity == System.Xml.Schema.XmlSeverityType.Error; });
    
       while (reader.Read()) { ; }
       reader.Close();
       return !errored;
    }

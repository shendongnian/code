        public static string SerializeXml<T>(T value) where T : class
    {
        if (value == null)
        {
            return null;
        }
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        XmlWriterSettings settings = new XmlWriterSettings();
        
        settings.Encoding = new UnicodeEncoding(false, false);
        settings.Indent = false;
        settings.OmitXmlDeclaration = false;
        // no BOM in a .NET string
        using (StringWriter textWriter = new StringWriter())
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
            {
                serializer.Serialize(xmlWriter, value);
            }
            return textWriter.ToString();
        }
    }

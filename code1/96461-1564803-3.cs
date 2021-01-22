    public static string Serialize<T>(T value) {
        if(value == null) {
            return null;
        }
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
        settings.Indent = false;
        settings.OmitXmlDeclaration = false;
        using(StringWriter textWriter = new StringWriter()) {
            using(XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings)) {
                serializer.Serialize(xmlWriter, value);
            }
            return textWriter.ToString();
        }
    }
    public static T Deserialize<T>(string xml) {
        if(string.IsNullOrEmpty(xml)) {
            return default(T);
        }
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        XmlReaderSettings settings = new XmlReaderSettings();
        // No settings need modifying here
        using(StringReader textReader = new StringReader(xml)) {
            using(XmlReader xmlReader = XmlReader.Create(textReader, settings)) {
                return (T) serializer.Deserialize(xmlReader);
            }
        }
    }

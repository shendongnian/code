    public static bool IsValidXml(string candidateString)
    {
        try
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.XmlResolver = null;
            XmlDocument document = new XmlDocument();
            document.XmlResolver = null;
            document.Load(XmlReader.Create(new MemoryStream(Encoding.UTF8.GetBytes(candidateString)), settings));
            return true;
        }
        catch (XmlException)
        {
            return false;
        }
    }

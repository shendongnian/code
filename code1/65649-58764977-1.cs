    public static bool IsValidXml(string candidateString)
    {
        try
        {
            var settings = new XmlReaderSettings { XmlResolver = null };
            var document = new XmlDocument() { XmlResolver = null };
            document.Load(XmlReader.Create(new MemoryStream(Encoding.UTF8.GetBytes(candidateString)), settings));
            return true;
        }
        catch (XmlException)
        {
            return false;
        }
    }

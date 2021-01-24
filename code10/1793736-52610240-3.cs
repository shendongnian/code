    public static XmlReader CreateXmlReaderFromBase64(string base64EncodedData, XmlReaderSettings settings = null)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return XmlReader.Create(new MemoryStream(base64EncodedBytes), settings);
    }

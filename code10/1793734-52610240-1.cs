    public static XmlReader FromBase64(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return XmlReader.Create(new MemoryStream(base64EncodedBytes));
    }

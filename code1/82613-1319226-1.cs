    private readonly string _byteOrderMarkUtf8 =
        Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
    
    public string GetXmlResponse(Uri resource)
    {
        string xml;
        using (var client = new WebClient())
        {
            client.Encoding = Encoding.UTF8;
            xml = client.DownloadString(resource);
        }
        if (xml.StartsWith(_byteOrderMarkUtf8, StringComparison.Ordinal))
        {
            xml = xml.Remove(0, _byteOrderMarkUtf8.Length);
        }
        return xml;
    }

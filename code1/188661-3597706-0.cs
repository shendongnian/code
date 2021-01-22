    ServiceDescription serviceDescription;
    using (WebClient client = new WebClient {Proxy = new WebProxy(host, port)})
    {
        using (Stream stream = client.OpenRead(webserviceUri))
        {
            using (XmlReader xmlreader = XmlReader.Create(stream))
            {
                serviceDescription = ServiceDescription.Read(xmlreader);
            }
        }
    }

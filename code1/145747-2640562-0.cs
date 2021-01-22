    public XmlDocument SendSoapRequest(XmlDocument soapRequest)
    {
        var webRequest = getWebRequest();
        Stream requestStream = webRequest.GetRequestStream();
        soapRequest.Save(requestStream);
        requestStream.Close();
        WebResponse webResponse = webRequest.GetResponse();
        requestStream = webResponse.GetResponseStream();
        var soapResponse = new XmlDocument();
        soapResponse.Load(new XmlTextReader(new StringReader(
            new StreamReader(requestStream).ReadToEnd()
        )));
        return soapResponse;
    }
    private HttpWebRequest getWebRequest()
    {
        var webRequest = (HttpWebRequest)WebRequest.Create(Url);
        webRequest.Credentials = CredentialCache.DefaultCredentials;
        webRequest.Headers.Add("SOAPAction", SoapAction);
        webRequest.ContentType = ContentType;
        webRequest.Accept = AcceptHeader;
        webRequest.Method = RequestMethod;
        return webRequest;
    }

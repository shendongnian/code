    protected virtual WebRequest CreateRequest(ISoapMessage soapMessage)
    {
    	var wr = WebRequest.Create(soapMessage.Uri);
    	wr.ContentType = "text/xml;charset=utf-8";
    	wr.ContentLength = soapMessage.ContentXml.Length;
    
    	wr.Headers.Add("SOAPAction", soapMessage.SoapAction);
    	wr.Credentials = soapMessage.Credentials;
    	wr.Method = "POST";
    	wr.GetRequestStream().Write(Encoding.UTF8.GetBytes(soapMessage.ContentXml), 0, soapMessage.ContentXml.Length);
    
    	return wr;
    }
    public interface ISoapMessage
    {
        string Uri { get; }
        string ContentXml { get; }
        string SoapAction { get; }
        ICredentials Credentials { get; }
    }

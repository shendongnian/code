    private HttpWebRequest DoInvokeRequest<T>(string uri, string method, T requestBody)
    {
        string destinationUrl = _baseUrl + uri;
	var invokeRequest = WebRequest.Create(destinationUrl) as HttpWebRequest;
	if (invokeRequest == null)
	    return null;
	invokeRequest.Method = method;
	invokeRequest.ContentType = "text/xml";
	byte[] requestBodyBytes = ToByteArray(requestBody);
	invokeRequest.ContentLength = requestBodyBytes.Length;
	AddRequestHeaders(invokeRequest);
	using (Stream postStream = invokeRequest.GetRequestStream())
	    postStream.Write(requestBodyBytes, 0, requestBodyBytes.Length);
	
	invokeRequest.Timeout = 60000;
	return invokeRequest;
    }
    private static byte[] ToByteArray<T>(T requestBody)
    {
        byte[] bytes;
	using (var s = new MemoryStream())
	{
	    var serializer = new XmlSerializer(typeof (T));
	    serializer.Serialize(s, requestBody);
	    bytes = s.ToArray();
	}
	return bytes;
    }

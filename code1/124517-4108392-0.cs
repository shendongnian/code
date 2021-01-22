    // Takes an input of the SOAP service URL (url) and the XML to be sent to the
    // service (xml).  
    public void PostXml(string url, string xml) 
    {
        byte[] bytes = Encoding.UTF8.GetBytes(xml);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentLength = bytes.Length;
        request.ContentType = "text/xml";
    
        using (Stream requestStream = request.GetRequestStream())
        {
           requestStream.Write(bytes, 0, bytes.Length);
        }
    
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                string message = String.Format("POST failed with HTTP {0}", 
                                               response.StatusCode);
                throw new ApplicationException(message);
            }
        }
    }

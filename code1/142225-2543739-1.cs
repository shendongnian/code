    Uri baseUri = new Uri(this.RemoteServer);
    HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create(new Uri(baseUri, action));
    rq.Method = "POST";
    rq.ContentType = "application/x-www-form-urlencoded";
    rq.Accept = "text/xml";
    rq.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
    Encoding encoding = Encoding.GetEncoding("UTF-8");
    byte[] chars = encoding.GetBytes(body);
    rq.ContentLength = chars.Length;
    using (Stream stream = rq.GetRequestStream())
    {
        stream.Write(chars, 0, chars.Length);
        stream.Close();
    }
    XDocument doc;
    WebResponse rs = rq.GetResponse();
    using (Stream stream = rs.GetResponseStream())
    {
        using (XmlTextReader tr = new XmlTextReader(stream))
        {
            doc = XDocument.Load(tr);
            responseXml = doc.Root;
        }
    
        if (responseXml == null)
        {
            throw new Exception("No response");
        }
     }
   
     return responseXml;

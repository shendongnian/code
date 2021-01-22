    // send request
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/xmlrpc/");
    request.Method = "POST";
    request.ContentType = "text/xml; encoding=utf-8";
    
    string content = "<?xml version='1.0'?><methodCall><methodName>app.getName</methodName><params></params></methodCall>"; 
    byte[] contentBytes = System.Text.UTF8Encoding.UTF8.GetBytes(content);						
    request.ContentLength = contentBytes.Length;
    using (Stream stream = request.GetRequestStream())
    {
    	stream.Write(contentBytes, 0, contentBytes.Length);	
    }
    
    // get response
    WebResponse response = request.GetResponse();
    XmlDocument xmlDoc = new XmlDocument();
    using (Stream responseStream = response.GetResponseStream())
    {
        xmlDoc.Load(responseStream);
    	Console.WriteLine(xmlDoc.OuterXml);
    }		

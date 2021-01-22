    HttpWebRequest req = (HttpWebRequest)WebRequest.Create("/ASPSession.ASP?SessionVar=" + SessionVarName);
    req.Headers.Add("Cookie: " + SessionCookieName + "=" + SessionCookieValue);
    
    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
    Stream receiveStream = resp.GetResponseStream();
    
    System.Text.Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
    
    StreamReader readStream = new StreamReader(receiveStream, encode);
    
    string response = readStream.ReadToEnd();
    
    resp.Close();
    readStream.Close();
    return response;

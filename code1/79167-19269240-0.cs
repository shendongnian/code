    WebRequest Webrequest;
    HttpWebResponse response;
    
    Webrequest = WebRequest.Create(Url);
    byte[] auth1 = Encoding.UTF8.GetBytes(UserName + ":" + Pwd);
    Webrequest.Headers["Authorization"] = "Basic " + System.Convert.ToBase64String(auth1);
    Webrequest.Method = "GET";
    Webrequest.ContentType = "application/atom+xml";
    
    response = (HttpWebResponse)Webrequest.GetResponse();
    Stream streamResponse = response.GetResponseStream();
    StreamReader streamReader = new StreamReader(streamResponse);
    string Response = streamReader.ReadToEnd();

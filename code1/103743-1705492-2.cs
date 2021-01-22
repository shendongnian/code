    public static HttpWebResponse SendPostRequest(string data, string url) 
    {
     
        //Data parameter Example
        //string data = "name=" + value
    
        HttpWebRequest httpRequest = HttpWebRequest.Create(url);
        httpRequest.Method = "POST";
        httpRequest.ContentType = "application/x-www-form-urlencoded";
        httpRequest.ContentLength = data.Length;
    
        var streamWriter = new StreamWriter(httpRequest.GetRequestStream());
        streamWriter.Write(data);
        streamWriter.Close();
    
        return httpRequest.GetResponse();
    }
    public static HttpWebResponse SendGetRequest(string url) 
    {
        
        HttpWebRequest httpRequest = HttpWebRequest.Create(url);
        httpRequest.Method = "GET";
        
        return httpRequest.GetResponse();
    }

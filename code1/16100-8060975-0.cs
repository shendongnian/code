    private string HTTPPost(string URL, Dictionary<string, string> FormData)
    {
                
        UTF8Encoding UTF8encoding = new UTF8Encoding();
        string postData = "";
        foreach (KeyValuePair<String, String> entry in FormData)
        {
                postData += entry.Key + "=" + entry.Value + "&";
        }
        postData = postData.Remove(postData.Length - 1);
        //urlencode replace (+) with (%2B) so it will not be changed to space ( )
        postData = postData.Replace("+", "%2B");
        byte[] data = UTF8encoding.GetBytes(postData); 
  
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
  
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = data.Length;
        Stream strm = request.GetRequestStream();
        // Send the data.
        strm.Write(data, 0, data.Length);
        strm.Close();
        WebResponse rsp = null;
        // Send the data to the webserver
        rsp = request.GetResponse();
        StreamReader rspStream = new StreamReader(rsp.GetResponseStream());
        string response = rspStream.ReadToEnd();
        return response;
    }

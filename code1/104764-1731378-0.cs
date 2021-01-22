    NameValueCollection nv = new NameValueCollection();
    nv.Add("username", "bob");
    nv.Add("password", "password");
    
    string method = "POST"; // or GET
    string url = "http://www.somesite.com/form.html";
    
    HttpStatusCode httpStatusCode;
    string response = SendHTTPRequest(nv, method, url, out httpStatusCode);
    public static string SendHTTPRequest(NameValueCollection data, 
             string method, 
             string url, 
             out HttpStatusCode httpStatusCode)
    {
      StringBuilder postData = new StringBuilder();
      foreach(string key in data)
      {
        postData.Append(key + "=" + data[key] + "&");
      }
    
      if(method == "GET" && data.Count > 0)
      {
        url += "?" + postData.ToString();
      }
    
      HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
      httpWebRequest.Method = method;
      httpWebRequest.Accept = "*/*";
      httpWebRequest.ContentType = "application/x-www-form-urlencoded";
    
      if(method == "POST")
      {
        using(Stream requestStream = httpWebRequest.GetRequestStream())
        {
          using(MemoryStream ms = new MemoryStream())
          {
            using(BinaryWriter bw = new BinaryWriter(ms))
            {
              bw.Write(Encoding.GetEncoding(1252).GetBytes(postData.ToString()));
              ms.WriteTo(requestStream);
            }
          }
        }
      }
    
      return GetWebResponse(httpWebRequest, out HttpStatusCode httpStatusCode);
    }
    
    private static string GetWebResponse(HttpWebRequest httpWebRequest, 
              out HttpStatusCode httpStatusCode)
    {
      using(HttpWebResponse httpWebResponse = 
               (HttpWebResponse)httpWebRequest.GetResponse())
      {
        httpStatusCode = httpWebResponse.StatusCode;
    
        if(httpStatusCode == HttpStatusCode.OK)
        {
          using(Stream responseStream = httpWebResponse.GetResponseStream())
          {
            using(StreamReader responseReader = new StreamReader(responseStream))
            {
              StringBuilder response = new StringBuilder();
    
              char[] read = new Char[256];
              int count = responseReader.Read(read, 0, 256);
    
              while(count > 0)
              {
                response.Append(read, 0, count);
                count = responseReader.Read(read, 0, 256);
              }
              responseReader.Close();
              return response.ToString();
            }
          }
        }
        return null;
      }
    }

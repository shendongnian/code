    var req = (HttpWebRequest)WebRequest.Create(url);
    req.Method = "POST";
    req.ContentLength = postContent.Length;
    req.ContentType = "application/x-www-form-urlencoded";
    
    using (var streamWriter = new StreamWriter(req.GetRequestStream()))
    {
        streamWriter.Write(postContent);
    }
    
    using (var res = (HttpWebResponse)req.GetResponse())
    {
      _status = res.StatusCode;
      using (var streamReader = new StreamReader(res.GetResponseStream()))
      {
        response = streamReader.ReadToEnd();
      }
    }		

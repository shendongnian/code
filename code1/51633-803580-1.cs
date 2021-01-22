    HttpWebRequest wReq = (HttpWebRequest)WebRequest.Create("http://www.mysite.com");
    using (HttpWebResponse resp = (HttpWebResponse)wReq.GetResponse())
    {
       // NOTE: A better approach would be to use the encoding returned by the server in
       // the Response headers (I'm using UTF 8 for brevity)
       using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
       {
           string content = sr.ReadToEnd();
           // Do something with the content
       }
    }    

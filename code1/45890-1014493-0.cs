    System.Net.WebRequest req = System.Net.WebRequest.Create("your url");
    
    req.ContentType = "text/xml";
    req.Method = "POST";
    
    byte[] bytes = System.Text.Encoding.ASCII.GetBytes("Your Data");
    req.ContentLength = bytes.Length;
    os = req.GetRequestStream();
    os.Write(bytes, 0, bytes.Length); 
    
    
    System.Net.WebResponse resp = req.GetResponse();
    if (resp == null) return;
    System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
    
    str responsecontent = sr.ReadToEnd().Trim();

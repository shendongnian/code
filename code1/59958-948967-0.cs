    private string GetSourceCode(string sourceUrl) {
       String url = String.Format(sourceUrl);
    
       WebClient client = new WebClient();
       client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0;)"); // pass as Internet Explorer 7.0
    
       Stream data = client.OpenRead(url);
       StreamReader reader = new StreamReader(data);
       s = reader.ReadToEnd();
       data.Close();
       reader.Close();
    
       return s;
    }

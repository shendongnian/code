    String url = "https://en.wikipedia.org/wiki/Sigiriya";
    
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "GET";
    request.Timeout = Timeout.Infinite;
    request.KeepAlive = true;
    
    long length = 0;
    try {               
    
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {
            length = response.ContentLength;
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);                  
        }
    } catch (Exception ex) {
       Console.WriteLine(ex);   
    }

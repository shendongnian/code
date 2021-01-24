    List<string> webServiceCollection = new List<string>();
    webServiceCollection.Add("http://<site>/_vti_bin/Lists.asmx");
    webServiceCollection.Add("http://<site>/_vti_bin/Sites.asmx");
    
      foreach(var reqeust in webServiceCollection) 
      {
        string completeUrl = $"<a href="request">{request}</a>";;
    
        // Create a request for the URL.         
        WebRequest request = WebRequest.Create(completeUrl);
    
        // If required by the server, set the credentials.
        request.Credentials = CredentialCache.DefaultCredentials;
    
    
        // If you have a proxy configured.
        WebProxy proxyObject = new WebProxy("<a href="http://proxy.com/">http://proxy.com/</a>", true);
        request.Proxy = proxyObject;
        
        
        //Get the response.
        using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
          // Get the stream containing content returned by the server.
          using(Stream dataStream = response.GetResponseStream())
          {
            // Open the stream using a StreamReader for easy access.
            using(StreamReader reader = new StreamReader(dataStream))
            {
               // Read the content.
               string responseFromServer = reader.ReadToEnd();   
            }
          }
        }
      }

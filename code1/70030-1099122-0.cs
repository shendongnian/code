    // assume your XML string is returned from GetXmlString()
    string xml = GetXmlString();
    // assume port 8080
    string url = new UriBuilder("http","www.example.com",8080).ToString();     
    
    // create a client object
    using(System.Web.WebClient client = new WebClient()) {
        // performs an HTTP POST
        client.UploadString(url, xml);  
    
    }

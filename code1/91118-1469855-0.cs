    // create a client object
    using(System.Net.WebClient client = new System.Net.WebClient()) {
        // performs an HTTP POST
        client.UploadString(url, xml);  
    
    }

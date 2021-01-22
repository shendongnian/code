    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("{0}?{1}",
        URLToHit,
        queryString));
    request.Method = "GET";
    request.Timeout = 1000; // set 1 sec. timeout
    request.ProtocolVersion = HttpVersion.Version11; // use HTTP 1.1
    
    try
    {
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        
        // Code here runs if GetResponse() was successful.
    }
    catch (WebException ex)
    {
        // Code here runs if GetResponse() failed.
    }
    
    // Code here is always run unless another exception is thrown. 

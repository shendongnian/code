    string url = "http://stopbyte.com"; // Just a sample url
    WebClient wc = new WebClient();
     
    wc.QueryString.Add("parameter1", "Hello world");
    wc.QueryString.Add("parameter2", "www.stopbyte.com");
    wc.QueryString.Add("parameter3", "parameter 3 value.");
     
    var data = wc.UploadValues(url, "POST", wc.QueryString);
     
    // data here is optional, in case we recieve any string data back from the POST request.
    var responseString = UnicodeEncoding.UTF8.GetString(data);

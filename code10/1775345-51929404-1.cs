    string url = ""; // url of the endpoint
    
    WebClient client = new WebClient();
    ServicePointManager.Expect100Continue = true;
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
    client.Encoding = Encoding.UTF8;
    client.Headers.Add("content-type", "application/json"); // same as other parameters in the header
                
    var data = client.DownloadString(url);

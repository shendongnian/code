    public bool DownloadFeed()
    {
        string user = "xxx";
        string password = "pwd";
        
        System.Net.WebClient wc = new System.Net.WebClient();
        string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password));
        wc.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
        System.Net.ServicePointManager.SecurityProtocol =      System.Net.SecurityProtocolType.Ssl3 | 
                                                        SecurityProtocolType.Tls | 
                                                        SecurityProtocolType.Tls11 | 
                                                        SecurityProtocolType.Tls12;
        wc.DownloadFile(@"https://Entered RSS Feed URL here", @"H:\import\Test.xml");
        return true;
    }

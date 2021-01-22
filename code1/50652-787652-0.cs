    System.Diagnostics.Stopwatch sw = new Stopwatch()
    System.Net.HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("http://www.example.com");
    // other request details, credentials, proxy settings, etc...
    
    sw.Start();
    System.Net.HttpWebResponse res = (HttpWebResponse)req.GetResponse();
    sw.Stop();
    
    TimeSpan timeToLoad = sw.Elapsed;

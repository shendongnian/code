    string Url ="http://www.cftc.gov/files/dea/history/com_disagg_txt_2018.zip";
    Uri URI = new Uri(Url, UriKind.Absolute);
    WebClient_DownLoad(URI, FileName);
    public void WebClient_DownLoad(Uri URI, string FileName)
    {
        using (WebClient webclient = new WebClient())
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                
            webclient.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
            webclient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0");
            webclient.Headers.Add(HttpRequestHeader.Accept, "ext/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            webclient.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8");
            webclient.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate;q=0.8");
            webclient.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
            webclient.Headers.Add(HttpRequestHeader.KeepAlive, "keep-alive");
            webclient.UseDefaultCredentials = true;
            webclient.DownloadFileCompleted += new AsyncCompletedEventHandler(WebClient_DownloadComplete);
            webclient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClient_DownloadProgress);
            webclient.DownloadFileAsync(URI, FileName);
        };
    }
    private void WebClient_DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
    {
        string Result = string.Format("Received: {0}  Total: {1}  Percentage: {2}", 
                             e.BytesReceived, e.TotalBytesToReceive, e.ProgressPercentage);
        //Update the UI
        Console.WriteLine(Result);
    }
    private static void WebClient_DownloadComplete(object sender, AsyncCompletedEventArgs e)
    {
        if (!e.Cancelled)
        {
            if (e.Error != null)
                // Update the UI: transfer completed.
                Console.WriteLine("Error: " + e.Error.Message);
                
        }else{
            // Update the UI: transfer Cancelled.
            Console.WriteLine("Cancelled");
        }
    }

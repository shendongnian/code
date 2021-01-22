    string address = "http://stackoverflow.com/";
    using (WebClient wc = new WebClient())
    {
        wc.DownloadStringCompleted +=
            new DownloadStringCompletedEventHandler(DownloadCompleted);
        wc.DownloadStringAsync(new Uri(address));
    }
    // ...
    void DownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        if ((e.Error == null) && !e.Cancelled)
        {
            string content = e.Result;
        }
    }

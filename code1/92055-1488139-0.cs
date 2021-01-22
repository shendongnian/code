    public void downloadphoto(string struri, string strtitle, string placeid)
    {
        using (WebClient wc = new WebClient())
        {
            wc.DownloadDataCompleted += (sender, args) => 
                DownloadDataCompleted(strtitle, placeid, args);
            wc.DownloadDataAsync(new Uri(struri));
        }
    }
    // Please rename the method to say what it does rather than where it's used :)
    private void DownloadDataCompleted(string title, string id, 
                                       DownloadDataCompletedEventArgs args)
    {
        // Do stuff here
    }

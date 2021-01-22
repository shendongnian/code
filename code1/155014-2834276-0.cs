    private void DownloadAdditionalThings()
    {
        WebRequest.RegisterPrefix("http://", System.Net.Browser.WebRequestCreator.ClientHttp);
        var client = new WebClient();
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential("username", "password");
        client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
        client.DownloadStringAsync(new Uri("http://blog.gfader.com/"));
    }
    
    private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        string result = e.Result;
    }

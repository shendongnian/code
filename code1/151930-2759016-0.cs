    private void btn1_Click(object sender, RoutedEventArgs e)
    {
        string url = "http://www.nu.nl/feeds/rss/algemeen.rss";
        this.client.DownloadStringAsync(new Uri(url));
    }
    private void ClientDownloadStringCompleted(object sender, 
                          DownloadStringCompletedEventArgs e)
    {
        try
        {
            Dispatcher.BeginInvoke(() => this.txbSummery.Text = e.Result ?? "");
        }
        catch (TargetInvocationException tiex)
        {
            throw tiex.InnerException;
        }
    }

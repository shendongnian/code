    static ManualResetEvent evnts = new ManualResetEvent(false);
    static void Main(string[] args)
    {
        byte[] data = null;
        WebClient client = new WebClient();
        client.DownloadDataCompleted += 
            delegate(object sender, DownloadDataCompletedEventArgs e)
            {
                 data = e.Result;
                 evnts.Set();
            };
        Console.WriteLine("starting...");
        evnts.Reset();
        client.DownloadDataAsync(new Uri("http://stackoverflow.com/questions/"));
        evnts.WaitOne(); // wait to download complete
        
        Console.WriteLine("done. {0} bytes received;", data.Length);
    }

    static void Main()
    {
        var client = new WebClient();
        client.DownloadStringCompleted += DownloadStringCompleted;
        client.DownloadStringAsync(new Uri("http://google.com"));
        Console.ReadLine();
    }
    static void DownloadStringCompleted(object sender,
        DownloadStringCompletedEventArgs e)
    {
        if (e.Error == null && !e.Cancelled)
        {
            Console.WriteLine(e.Result);
        }
    }

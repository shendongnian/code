    static void Main()
    {
        string url = "http://google.com";
        WebClient client = new WebClient();
        client.DownloadDataCompleted += DownloadDataCompleted;
        client.DownloadDataAsync(new Uri(url));
        Console.ReadLine();
    }
    static void DownloadDataCompleted(object sender,
        DownloadDataCompletedEventArgs e)
    {
        byte[] raw = e.Result;
        Console.WriteLine(raw.Length + " bytes received");
    }

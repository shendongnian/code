    static void Main(string[] args)
    {
        var wc = new WebClient();
        wc.DownloadStringCompleted += (sender, e) => Console.WriteLine(e.Result);
        wc.DownloadStringAsync(new Uri("http://example.com/version.txt"));
        Console.WriteLine("END OF APP ---------------------- ");
        Console.ReadKey();
        wc.Dispose();
    }

    static void Main(string[] args)
    {
        using (var wc = new WebClient()) {
            wc.DownloadStringCompleted += (sender, e) => Console.WriteLine(e.Result);
            wc.DownloadStringAsync(new Uri("http://example.com/version.txt"));
        }
        Console.WriteLine("END OF APP ---------------------- ");
        Console.ReadKey();
    }

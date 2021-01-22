    static void Main(string[] args)
    {
        System.Net.WebClient c = new WebClient();
        c.DownloadDataCompleted += 
             new DownloadDataCompletedEventHandler(c_DownloadDataCompleted);
        c.DownloadDataAsync(new Uri("http://www.msn.com"));
        Console.ReadKey();
    }
    static void c_DownloadDataCompleted(object sender, 
                                        DownloadDataCompletedEventArgs e)
    {
        Console.WriteLine(Encoding.ASCII.GetString(e.Result));
    }

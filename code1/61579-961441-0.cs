    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();
            client.DownloadProgressChanged += (sender, e) =>
            {
                Console.WriteLine("{0}% completed", e.ProgressPercentage);
            };
            client.DownloadStringCompleted += (sender, e) =>
            {
                // e.Result contains downloaded string
                Console.WriteLine("finished downloading...");
            };
            client.DownloadStringAsync(new Uri("http://www.stackoverflow.com"));
            Console.ReadKey();
        }
    }

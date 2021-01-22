    class Program
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                Stopwatch watch = Stopwatch.StartNew();
                var data = client.DownloadData("http://news.bbc.co.uk");
                watch.Start();
                Console.WriteLine("{0} ms", watch.ElapsedMilliseconds);
            }
        }
    }

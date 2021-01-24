        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            TokenExperiment(cts);
            Thread.Sleep(2000);
            cts.Cancel();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        private static void TokenExperiment(CancellationTokenSource cts)
        {
            var token = cts.Token;
            Task.Factory.StartNew(() =>
            {
                try
                {
                    var client = new WebClient();
                    token.Register(() =>
                    {
                        client.CancelAsync();
                    });
                    client.DownloadData("http://ipv4.download.thinkbroadband.com/1GB.zip");
                }
                catch
                {
                    Console.WriteLine("Task was cancelled.");
                }
            }, token);
            Console.WriteLine("Task was started.");
        }

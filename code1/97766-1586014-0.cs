        byte[] data = null;
        WebClient client = new WebClient();
        client.DownloadDataCompleted += 
            delegate(object sender, DownloadDataCompletedEventArgs e)
            {
                 data = e.Result;
            };
        Console.WriteLine("starting...");
        client.DownloadDataAsync(new Uri("http://stackoverflow.com/questions/"));
        while (client.IsBusy)
        {
            Console.WriteLine("\twaiting...");
            Thread.Sleep(100);
        }
        Console.WriteLine("done. {0} bytes received;", data.Length);
    }

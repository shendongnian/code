        WebClient wc = new WebClient();
        wc.DownloadFileCompleted += (sender, args) =>
        {
            if (args.Cancelled) Console.WriteLine("cancelled");
            else if (args.Error != null) Console.WriteLine(args.Error.Message);
            else Console.WriteLine("got it");
        };
        wc.DownloadFileAsync(uri, filePath);
        // wc.CancelAsync(); // to abort

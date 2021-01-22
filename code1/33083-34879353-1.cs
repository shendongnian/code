        void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("Download status: {0}%.", e.ProgressPercentage);
        }
        void WebClientDownloadCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            Console.WriteLine("Download finished!");
        }

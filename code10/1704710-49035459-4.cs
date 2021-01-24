    public class Client
    {
        public string Download(string url)
        {
            // setup work
            string fileName = GenerateFileName();
            // download file
            using (var wc = new WebClient())
            {
                wc.DownloadProgressChanged += OnDownloadProgressChanged;
                wc.DownloadFileCompleted += OnDownloadFileCompleted;
                DownloadResult downloadResult = DownloadResult.CompletedSuccessfuly;
                void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
                {
                    if (otherObject.ShouldCancel)
                    {
                        ((WebClient)sender).CancelAsync();
                    }
                }
                void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
                {
                    if (e.Cancelled)
                    {
                        downloadResult = DownloadResult.Cancelled;
                        return;
                    }
                    if (e.Error != null)
                    {
                        downloadResult = DownloadResult.ErrorOccurred;
                        return;
                    }
                }
                try
                {
                    Task task = wc.DownloadFileTaskAsync(url, fileName);
                    task.Wait();
                }
                catch (AggregateException ex)
                {
                }
                switch (downloadResult)
                {
                    case DownloadResult.CompletedSuccessfuly:
                        break;
                    case DownloadResult.Cancelled:
                        break;
                    case DownloadResult.ErrorOccurred:
                        break;
                }
            }
            // Other work after downloading, regardless of cancellation.
            // Could include in OnDownloadCompleted as long as this
            // method blocked until all work was complete
            return fileName;
        }
    }
    public enum DownloadResult
    {
        CompletedSuccessfuly,
        Cancelled,
        ErrorOccurred
    }

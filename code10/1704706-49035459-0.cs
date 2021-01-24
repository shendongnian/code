    public class Client
    {
        public async Task<string> DownloadFileAsync(string url, string outputFileName, CancellationToken cancellationToken)
        {
            using (var webClient = new WebClient())
            {
                cancellationToken.Register(webClient.CancelAsync);
                
                try
                {
                    var task = webClient.DownloadFileTaskAsync(url, outputFileName);
                    await task; // This line throws an exception when cancellationTokenSource.Cancel() is called.
                }
                catch (WebException ex) when (ex.Message == "The request was aborted: The request was canceled.")
                {
                    throw new OperationCanceledException();
                }
                catch (TaskCanceledException)
                {
                    throw new OperationCanceledException();
                }
                return outputFileName;
            }
        }
    }

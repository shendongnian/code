        private async static void DownloadFile()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var client = new Client();
            var task = client.DownloadFileAsync("url",
                "output.exe", cancellationTokenSource.Token);
            cancellationTokenSource.Token.WaitHandle.WaitOne(TimeSpan.FromSeconds(5));
            cancellationTokenSource.Cancel();
            try
            {
                var result = await task;
            }
            catch (OperationCanceledException)
            {
                // Operation Canceled
            }
        }

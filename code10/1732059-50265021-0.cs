    public static async Task UploadFileAsync(string serverPath, string pathToFile, string authToken, IProgress<int> progress = null) {
        var tcs = new TaskCompletionSource<object>();
        serverPath = @"C:\_Series\S1\The 100 S01E03.mp4";
        using (var client = new WebClient()) {
            UploadProgressChangedEventHandler uploadProgressChanged = null;
            if (progress != null) {
                uploadProgressChanged = (s, e) => {
                    var percentage = e.ProgressPercentage;
                    progress.Report(percentage);
                };
                client.UploadProgressChanged += uploadProgressChanged;
            }
            UploadFileCompletedEventHandler uploadCompletedCallback = null;
            uploadCompletedCallback = (s, e) => {
                //unsubscribe to events
                client.UploadFileCompleted -= uploadCompletedCallback;
                if (progress != null)
                    client.UploadProgressChanged -= uploadProgressChanged;
                if (e.Cancelled)
                    tcs.TrySetCanceled();
                else if (e.Error != null)
                    tcs.TrySetException(e.Error);
                else
                    tcs.TrySetResult(null);
            };
            client.UploadFileCompleted += uploadCompletedCallback;
            var uri = new Uri($"http://localhost:50424/api/File/Upload?serverPath={WebUtility.UrlEncode(serverPath)}");
            client.UploadFileAsync(uri, "POST", pathToFile);
            await tcs.Task;
        }
    }
    

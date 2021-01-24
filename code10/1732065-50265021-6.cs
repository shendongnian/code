    public static async Task UploadFileAsync(string serverPath, string pathToFile, string authToken, IProgress<int> progress = null) {
        serverPath = @"C:\_Series\S1\The 100 S01E03.mp4";
        using (var client = new WebClient()) {
            // Wrap Event-Based Asynchronous Pattern (EAP) operations 
            // as one task by using a TaskCompletionSource<TResult>.
            var task = createTask(client, progress);
            var uri = new Uri($"http://localhost:50424/api/File/Upload?serverPath={WebUtility.UrlEncode(serverPath)}");
            client.UploadFileAsync(uri, "POST", pathToFile);
            //wait here while the file uploads
            await task;
        }
    }
    private static Task createTask(WebClient client, IProgress<int> progress = null) {
        var tcs = new TaskCompletionSource<object>();
        #region callbacks
        // Specifiy the callback for UploadProgressChanged event
        // so it can be tracked and relayed through `IProgress<T>`
        // if one is provided
        UploadProgressChangedEventHandler uploadProgressChanged = null;
        if (progress != null) {
            uploadProgressChanged = (sender, args) => progress.Report(args.ProgressPercentage);
            client.UploadProgressChanged += uploadProgressChanged;
        }
        // Specify the callback for the UploadFileCompleted
        // event that will be raised by this WebClient instance.
        UploadFileCompletedEventHandler uploadCompletedCallback = null;
        uploadCompletedCallback = (sender, args) => {
            // unsubscribing from events after asynchronous
            // events have completed
            client.UploadFileCompleted -= uploadCompletedCallback;
            if (progress != null)
                client.UploadProgressChanged -= uploadProgressChanged;
            if (args.Cancelled) {
                tcs.TrySetCanceled();
                return;
            } else if (args.Error != null) {
                // Pass through to the underlying Task
                // any exceptions thrown by the WebClient
                // during the asynchronous operation.
                tcs.TrySetException(args.Error);
                return;
            } else
                //since no result object is actually expected
                //just set it to null to allow task to complete
                tcs.TrySetResult(null);
        };
        client.UploadFileCompleted += uploadCompletedCallback;
        #endregion
        // Return the underlying Task. The client code
        // waits on the task to complete, and handles exceptions
        // in the try-catch block there.
        return tcs.Task;
    }
    

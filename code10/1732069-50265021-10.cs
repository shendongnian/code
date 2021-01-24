    private static Task createTask(this WebClient client, IProgress<int> progress = null) {
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
    

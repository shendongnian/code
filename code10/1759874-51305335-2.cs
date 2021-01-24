    public async Task UploadFileAsync(Uri uri, string file)
    {
        using (var client = new WebClient())
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            client.UploadProgressChanged += UploadProgressChanged;
            // this sets the task to completed when the upload finished
            client.UploadFileCompleted += (sender, e) => tcs.SetResult(0);
            
            client.UploadFileAsync(uri, "PUT", file);
            await tcs.Task.ConfigureAwait(false);
        }
    }

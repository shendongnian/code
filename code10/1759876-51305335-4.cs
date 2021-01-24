    // return the byte[] result
    public async Task<byte[]> UploadFileAsync(Uri uri, string file)
    {
        using (var client = new WebClient())
        {
            // use correct result type for taskcompletionsource
            TaskCompletionSource<byte[]> tcs = new TaskCompletionSource<byte[]>();
            client.UploadProgressChanged += UploadProgressChanged;
            client.UploadFileCompleted += (sender, e) =>
            {
                if (e.Cancelled) // the upload has been cancelled
                    tcs.SetCancelled();
                else if (e.Error != null)
                    tcs.SetException(e.Error); // or faulted with an exception
                else
                    tcs.SetResult(e.Result); // or finished and returned a byte[]
            }
            client.UploadFileAsync(uri, "PUT", file);
            await tcs.Task.ConfigureAwait(false);
        }
    }

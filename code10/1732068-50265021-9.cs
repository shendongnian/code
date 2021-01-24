    public static async Task UploadFileAsync(string serverPath, string pathToFile, string authToken, IProgress<int> progress = null) {
        serverPath = @"C:\_Series\S1\The 100 S01E03.mp4";
        using (var client = new WebClient()) {
            // Wrap Event-Based Asynchronous Pattern (EAP) operations 
            // as one task by using a TaskCompletionSource<TResult>.
            var task = client.createUploadFileTask(progress);
            var uri = new Uri($"http://localhost:50424/api/File/Upload?serverPath={WebUtility.UrlEncode(serverPath)}");
            client.UploadFileAsync(uri, "POST", pathToFile);
            //wait here while the file uploads
            await task;
        }
    }

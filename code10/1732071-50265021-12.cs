    public static async Task UploadFileAsync(string serverPath, string pathToFile, string authToken, IProgress<int> progress = null) {
        using (var client = new WebClient()) {
            var uri = new Uri($"http://localhost:50424/api/File/Upload?serverPath={WebUtility.UrlEncode(serverPath)}");
            await client.PostFileAsync(uri, pathToFile, progress);
        }
    }
    

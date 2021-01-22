    WebClient webClient = new WebClient();
    webClient.UploadFileAsync(address, fileName);
    webClient.UploadProgressChanged += WebClientUploadProgressChanged;
...
    void WebClientUploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
    {
            Console.WriteLine("Download {0}% complete. ", e.ProgressPercentage);
    }

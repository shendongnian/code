    WebClient webClient = new WebClient();
    webClient.UploadFileAsync(address, fileName);
    webClient.UploadProgressChanged += WebClientUploadProgressChanged;
...
    void WebClientUploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
    {
            Console.WriteLine("Upload {0}% complete. ", e.ProgressPercentage);
    }

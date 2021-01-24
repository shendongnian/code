    private async void functionName()
    {
        foreach (var category in jsonCollection.Categories)
        {
            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                await client.DownloadFileTaskAsync(new Uri(category.Url), @"G:\\PROJECT\\BCCP\\file_name");
                //await for downloading
                lblFileName.Text = category.File_name;
            });
            thread.Start();
        }
    }

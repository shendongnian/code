        private async TaskDownloadFile(string Filename, Uri Uri)
            {
        
                Console.WriteLine(Filename + " " + Uri);
                _download_completed = false;
                WebClient client = new WebClient();
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
             
          await   client.DownloadFileTaskAsync(Uri, Filename);
        
            }

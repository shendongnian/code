    public void DownloadImage(string URL)
            {
                var webClient = new WebClient();
                webClient.DownloadDataCompleted += (s, e) =>
                {
                    byte[] bytes = new byte[e.Result.Length];
                    bytes=e.Result; // get the downloaded data
                    string documentsPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).AbsolutePath;
    
                    var partedURL = URL.Split('/');
                    string localFilename = partedURL[partedURL.Length-1];
                    string localPath = System.IO.Path.Combine(documentsPath, localFilename);
                    File.WriteAllBytes(localPath, bytes); // writes to local storage
                    Application.Current.MainPage.IsBusy = false;
                    Application.Current.MainPage.DisplayAlert("Download", "Download Finished", "OK");
                    MediaScannerConnection.ScanFile(Forms.Context,new string[] { localPath }, null, null);
                };
                var url = new Uri(URL);
                webClient.DownloadDataAsync(url);
            }

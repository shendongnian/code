        private void DownloadFile(string url)
        {
           var webClient = new WebClient();
           webClient.DownloadStringCompleted += (s, e) => {
           var text = e.Result; // get the downloaded text
           string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
           string localFilename = "downloaded.txt";
           string localPath = Path.Combine(documentsPath, localFilename);
           File.WriteAllText(localPath, text); // writes to local storage
        };
        var url = new Uri("http://xamarin.com");
        webClient.Encoding = Encoding.UTF8;
        webClient.DownloadStringAsync(url);
        RunOnUiThread(() => {
            Toast.MakeText(this, "Download Completed", ToastLength.Short).Show();
        });
        }

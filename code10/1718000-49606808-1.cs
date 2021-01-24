        private WebClient _webClient;
        public WebClient WebClient
        {
            get
            {
                if (_webClient == null)
                    _webClient = new WebClient();
                return _webClient;
            }
        }
        public string DownloadFileAsync(string url, string extension, string fileName)
        {
            string dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), 
                "clubs");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
             
            string filePath = Path.Combine(dir, fileName + extension);
            Uri uri = new Uri(url + extension);
            try
            {
                WebClient.DownloadFileAsync(uri, filePath);
                return "download complete of " + fileName;
            }
            catch (WebException webException)
            {
                Debug.WriteLine($"[{webException.Response}] - {webException.Message}");
            }
            catch (Exception ex)
            {
                return "404 File not downloaded: " + fileName;
            }
            return "404 File not downloaded: " + fileName;
        }

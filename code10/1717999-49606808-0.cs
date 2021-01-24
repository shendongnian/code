        private WebClient webClient;
        public string DownloadFileAsync(string url, string extension, string fileName)
        {
            if (webClient == null)
                webClient = new WebClient();
            string dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), 
                "clubs");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
             
            string filePath = Path.Combine(dir, fileName + extension);
            Uri uri = new Uri(url + extension);
            try
            {
                webClient.DownloadFileAsync(uri, filePath);
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

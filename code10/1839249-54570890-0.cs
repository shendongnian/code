        public void DownloadFile(string url, string token, string folder)
        {
            string pathToNewFolder = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, folder);
            Directory.CreateDirectory(pathToNewFolder);
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("API_KEY", App.Api_key);
                    client.Headers.Add("Authorization", "Bearer " + token);
                    using (Stream rawStream = client.OpenRead(url))
                    {
                        string fileName = string.Empty;
                        string contentDisposition = client.ResponseHeaders["content-disposition"];
                        if (!string.IsNullOrEmpty(contentDisposition))
                        {
                            string lookFor = "filename=";
                            int index = contentDisposition.IndexOf(lookFor, StringComparison.CurrentCultureIgnoreCase);
                            if (index >= 0)
                                fileName = contentDisposition.Substring(index + lookFor.Length);
                        }
                        string pathToNewFile = Path.Combine(pathToNewFolder, fileName);
                        client.DownloadFile(url, pathToNewFile);
                    }
                }
            }
            catch (Exception ex)
            {
                if (OnFileDownloaded != null)
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(false));
            }
        }

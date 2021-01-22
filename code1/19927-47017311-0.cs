    private string DownloadFile(string url)
        {
            
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            string filename = "";
            string destinationpath = Environment;
            if (!Directory.Exists(destinationpath))
            {
                Directory.CreateDirectory(destinationpath);
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result)
            {
                string path = response.Headers["Content-Disposition"];
                if (string.IsNullOrWhiteSpace(path))
                {
                    var uri = new Uri(url);
                    filename = Path.GetFileName(uri.LocalPath);
                }
                else
                {
                    ContentDisposition contentDisposition = new ContentDisposition(path);
                    filename = contentDisposition.FileName;
                }
                var responseStream = response.GetResponseStream();
                using (var fileStream = File.Create(System.IO.Path.Combine(destinationpath, filename)))
                {
                    responseStream.CopyTo(fileStream);
                }
            }
            return Path.Combine(destinationpath, filename);
        }

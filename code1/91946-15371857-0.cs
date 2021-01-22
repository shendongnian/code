        private static void DownloadFile(Uri remoteUri, string localPath)
        {
            var request = (HttpWebRequest)WebRequest.Create(remoteUri);
            request.Timeout = 30000;
            request.AllowWriteStreamBuffering = false;
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var s = response.GetResponseStream())
            using (var fs = new FileStream(localPath, FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = s.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, bytesRead);
                    bytesRead = s.Read(buffer, 0, buffer.Length);
                }
            }
        }

      public IEnumerable<FtpFileInfo> GetFiles(string server, string user, string password)
        {
            var credentials = new NetworkCredential(user, password);
            var baseUri = new Uri("ftp://" + server + "/");
            var files = new List<FtpFileInfo>();
            AddFilesFromSubdirectory(files, baseUri, credentials);
            return files;
        }
        private void AddFilesFromSubdirectory(List<FtpFileInfo> files, Uri uri, NetworkCredential credentials)
        {
            var client = new FtpClient(credentials);
            var lookedUpFiles = client.GetFiles(uri);
            files.AddRange(lookedUpFiles);
            foreach (var subDirectory in client.GetDirectories(uri))
            {
                AddFilesFromSubdirectory(files, subDirectory.Uri, credentials);
            }
        }

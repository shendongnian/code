        public void Upload(string targetUri, string filePath)
        {
            WebClient client = new WebClient();
            client.UploadProgressChanged += new UploadProgressChangedEventHandler(client_UploadProgressChanged);
            client.UploadFile(targetUri, filePath);
        }

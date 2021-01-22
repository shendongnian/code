    public void Upload(string targetUri, byte[] buffer)
        {
            WebClient client = new WebClient();
            client.UploadProgressChanged += new UploadProgressChangedEventHandler(client_UploadProgressChanged);
            client.UploadData(targetUri, buffer);
        }

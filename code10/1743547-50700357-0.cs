    public async Task UploadVideoFilesToBlobStorage(List<VideoUploadModel> videos, CancellationToken cancellationToken)
    {
        var blobTransferClient = new BlobTransferClient();
        //register events
        blobTransferClient.TransferProgressChanged += BlobTransferClient_TransferProgressChanged;
        //files
        _videoCount = _videoCountLeft = videos.Count;
        foreach (var video in videos)
        {
            var blobUri = new Uri(video.SasLocator);
            //create the sasCredentials
            var sasCredentials = new StorageCredentials(blobUri.Query);
            //get the URL without sasCredentials, so only path and filename.
            var blobUriBaseFile = new Uri(blobUri.GetComponents(UriComponents.SchemeAndServer | UriComponents.Path,
                UriFormat.UriEscaped));
            //get the URL without filename (needed for BlobTransferClient (seems to me like a issue)
            var blobUriBase = new Uri(blobUriBaseFile.AbsoluteUri.Replace("/"+video.Filename, ""));
            var blobClient = new CloudBlobClient(blobUriBaseFile, sasCredentials);
            //upload using stream, other overload of UploadBlob forces to put online filename of local filename
            using (FileStream fs = new FileStream(video.FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                await blobTransferClient.UploadBlob(blobUriBase, video.Filename, fs, null, cancellationToken, blobClient, 
                    new NoRetry(), "video/x-msvideo");
            }
            _videoCountLeft -= 1;
        }
        
        blobTransferClient.TransferProgressChanged -= BlobTransferClient_TransferProgressChanged;
    }
    private void BlobTransferClient_TransferProgressChanged(object sender, BlobTransferProgressChangedEventArgs e)
    {
        Console.WriteLine("progress, seconds remaining:" + e.TimeRemaining.Seconds);
        double bytesTransfered = e.BytesTransferred;
        double bytesTotal = e.TotalBytesToTransfer;
        double thisProcent = bytesTransfered / bytesTotal;
        double procent = thisProcent;
        //devide by video amount
        int videosUploaded = _videoCount - _videoCountLeft;
        if (_videoCountLeft > 0)
        {
            procent = (thisProcent + videosUploaded) / _videoCount;
        }
        procent = procent * 100;//to real %
        UploadProgressChangedEvent?.Invoke((int)procent, videosUploaded, _videoCount);
    }

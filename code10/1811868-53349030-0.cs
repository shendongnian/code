    void VideosInsertRequest_ProgressChanged(Google.Apis.Upload.IUploadProgress progress)
    {
        switch (progress.Status)
        {
            case UploadStatus.Uploading:
                UpdateStatus(String.Format("{0} bytes sent.", progress.BytesSent));
                break;
            case UploadStatus.Failed:
                UpdateStatus(String.Format("An error prevented the upload from completing.{0}", progress.Exception));
                break;
        }
    }
    void VideosInsertRequest_ResponseReceived(Video video)
    {
        UpdateStatus(string.Format("Video id '{0}' was successfully uploaded.", video.Id));
    }
    private void UpdateStatus(string status)
    {
        StatusLabel.Dispatcher.BeginInvoke(new Action(() => { StatusLabel.Content = status; }));
    }

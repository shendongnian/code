    private static void ProcessDirectory(System.IO.DirectoryInfo di)
    {
        int _timeOut = 5 * 60 * 1000;
        foreach (var item in di.GetDirectories())
        {
            ProcessDirectory(item);
        }
        using (Amazon.S3.AmazonS3Client _client = new Amazon.S3.AmazonS3Client())
        {
            CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
            Dictionary<string, Task<Amazon.S3.Model.PutObjectResponse>> _responses =
                new Dictionary<string, Task<Amazon.S3.Model.PutObjectResponse>>(1000);
            foreach (var item in di.GetFiles())
            {
                // use any unique information about your item here
                var itemName = item.FullName;
                _responses[itemName] = _client.PutObjectAsync(new Amazon.S3.Model.PutObjectRequest
                {
                    BucketName = SiteSettings.Bucket,
                    CannedACL = Amazon.S3.S3CannedACL.PublicRead,
                    FilePath = itemName,
                    Key = item.FullName.Replace(SiteSettings.OutputRoot, string.Empty).Replace(@"\", "/")
                }, _cancellationTokenSource.Token);
            }
            // Wait 5 Mins + 1 sec
            Task.WhenAny(Task<Amazon.S3.Model.PutObjectResponse>.WhenAll(_responses.Values)
                ,Task.Delay(_timeOut)).Wait(_timeOut + 1000);
            _cancellationTokenSource.Cancel(); //Cancel the remaining pushes for this folder.
            foreach (var item in _responses)
            {
                if (!item.Value.IsCompleted)
                {
                    //Pull the key value to log
                    var keyValue = item.Key;
                }
            }
        }
    }

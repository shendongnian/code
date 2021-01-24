    public async Task DownloadDirectoryAsync()
    {
        var bucketRegion = RegionEndpoint.USEast2;
        var credentials = new BasicAWSCredentials(accessKey, secretKey);
        var client = new AmazonS3Client(credentials, bucketRegion);
    
        var bucketName = "bucketName";
        var request = new ListObjectsV2Request
        {
            BucketName = bucketName,
            Prefix = "directorey/",
            MaxKeys = 1000
        };
    
        var response = await client.ListObjectsV2Async(request);
        var utility = new TransferUtility(s3Client);
        var downloadPath = "c:\\your_folder";
        foreach (var obj in response.S3Objects)
        {
            utility.Download($"{downloadPath}\\{obj.Key}", bucketName, obj.Key);
        }
    } 

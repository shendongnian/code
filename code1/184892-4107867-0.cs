    public bool Exists(string fileKey, string bucketName)
    {
            try
            {
                response = _s3Client.GetObjectMetadata(new GetObjectMetadataRequest()
                   .WithBucketName(bucketName)
                   .WithKey(key));
                return true;
            }
            catch (Amazon.S3.AmazonS3Exception ex)
            {
                if (ex.Message.Contains("404"))
                    return false;
            }
    }

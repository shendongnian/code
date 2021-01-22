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
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return false;
                //status wasn't not found, so throw the exception
                throw;
            }
    }

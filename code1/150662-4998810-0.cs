    public static S3Bucket GetS3Bucket(string bucket)
    {
        try
        {
            AmazonS3 client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKeyID, secretAccessKeyID);
            return client.ListBuckets().Buckets.Where(b => b.BucketName == bucket).Single();
        }
        catch (AmazonS3Exception amazonS3Exception)
        {
            throw amazonS3Exception;
        }
    }

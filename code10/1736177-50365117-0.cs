            AmazonS3Client s3Client = new AmazonS3Client(AccessKey, SecretKey, Amazon.RegionEndpoint.USEast1);
            try
            {
                var buckets = s3Client.GetBucketLocationAsync("some-bucket").Result;
            }
            catch (AmazonS3Exception ex)
            {
                  //do something when you can't access to your bucket
            }

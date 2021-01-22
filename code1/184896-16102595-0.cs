    using (client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKey, secretKey))
            {
                S3FileInfo s3FileInfo = new Amazon.S3.IO.S3FileInfo(client, bucket, "sample/" + txtImageExists.Text);
                if (s3FileInfo.Exists)
                {
                     // image exists
                }
                else
                {
                    
                }
               
            }

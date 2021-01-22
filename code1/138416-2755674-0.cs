    string bucketName = "bucket";
    string key = "some/key/name.bin";
    string dest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "name.bin");
    
    using (AmazonS3 client = Amazon.AWSClientFactory.CreateAmazonS3Client(AWSAccessKeyID, AWSSecretAccessKeyID))
    {
        GetObjectRequest getObjectRequest = new GetObjectRequest().WithBucketName(bucketName).WithKey(key);
    
        using (S3Response getObjectResponse = client.GetObject(getObjectRequest))
        {
            if (!File.Exists(dest))
            {
                using (Stream s = getObjectResponse.ResponseStream)
                {
                    using (FileStream fs = new FileStream(dest, FileMode.Create, FileAccess.Write))
                    {
                        byte[] data = new byte[32768];
                        int bytesRead = 0;
                        do
                        {
                            bytesRead = s.Read(data, 0, data.Length);
                            fs.Write(data, 0, bytesRead);
                        }
                        while (bytesRead > 0);
                        fs.Flush();
                    }
                }
            }
        }
    }

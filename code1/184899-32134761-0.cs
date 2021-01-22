     using (IAmazonS3 s3Client = new AmazonS3Client(accessKey, secretKey))
                {
                    S3DirectoryInfo s3DirectoryInfo = new Amazon.S3.IO.S3DirectoryInfo(s3Client, "testbucket");
                    if (s3DirectoryInfo.GetFiles("test*").Any())
                    {
                        //file exists -- do something
                    }
                    else
                    {
                        //file doesn't exist -- do something else
                    }
    
                }

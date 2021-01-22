        NameValueCollection appConfig = ConfigurationManager.AppSettings;
    
            AmazonS3 s3Client = AWSClientFactory.CreateAmazonS3Client(
                    appConfig["AWSAccessKey"],
                    appConfig["AWSSecretKey"],
                    Amazon.RegionEndpoint.USEast1
                    );
    
    S3DirectoryInfo source = new S3DirectoryInfo(s3Client, "BUCKET_NAME", "Key");
    if(source.Exist)
    {
       //do ur stuff
    }

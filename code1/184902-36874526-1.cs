    BasicAWSCredentials credentials = new BasicAWSCredentials("accessKey", "secretKey");
    AmazonS3Config configurationAmazon = new AmazonS3Config();
    configurationAmazon.RegionEndpoint = S3Region.EU; // or you can use ServiceUrl
    AmazonS3Client s3Client = new AmazonS3Client(credentials, configurationAmazon);
    S3DirectoryInfo directoryInfo = new S3DirectoryInfo(s3Client, bucketName);
                bucketExists = directoryInfo.Exists;// true if the bucket exists in other case false.

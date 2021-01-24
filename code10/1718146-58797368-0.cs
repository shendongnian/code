    Bucketname, Accesskey and secretkey, I took from web config. You could type manually.
     public void DownloadObject(string imagename)
        {
            RegionEndpoint bucketRegion = RegionEndpoint.USEast1;
            IAmazonS3 client = new AmazonS3Client(bucketRegion);
          
            string accessKey = System.Configuration.ConfigurationManager.AppSettings["AWSAccessKey"];
            string secretKey = System.Configuration.ConfigurationManager.AppSettings["AWSSecretKey"];            
            AmazonS3Client s3Client = new AmazonS3Client(new BasicAWSCredentials(accessKey, secretKey), Amazon.RegionEndpoint.USEast1);
            string objectKey = "EMR" + "/" + imagename;
            //EMR is folder name of the image inside the bucket 
            GetObjectRequest request = new GetObjectRequest();
            request.BucketName = System.Configuration.ConfigurationManager.AppSettings["bucketname"];      
            request.Key = objectKey;
            GetObjectResponse response = s3Client.GetObject(request);         
            response.WriteResponseStreamToFile("D:\\Test\\"+ imagename);
        }

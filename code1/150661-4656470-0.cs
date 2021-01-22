    using (AmazonS3 client = Amazon.AWSClientFactory.CreateAmazonS3Client(AWSKey, AWSSecretKey)) {
    
    	object req = new Model.ListObjectsRequest { BucketName = "MyBucket" };
    	object resp = client.ListObjects(req);
    
    }

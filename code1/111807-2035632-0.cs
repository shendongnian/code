    public string postFile(HttpPostedFile file)
    {
    	var recFile = file;
    	try
    	{
    		var client = AWSClientFactory.CreateAmazonS3Client(accessKeyID, secretAccessKeyID);
    		var request = new PutObjectRequest();
    
    		request.WithMetaData("title", "the title")
    		request.WithInputStream(recFile.InputStream); //** Using InputStream
    		request.WithBucketName(bucketName);
    		request.WithKey(keyName);
    
    		using (S3Response response = client.PutObject(request))
    		{
    			return keyName;
    		}
    	......

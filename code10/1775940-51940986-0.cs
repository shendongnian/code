        RegionEndpoint bucketRegion = RegionEndpoint.USWest2;//region where you store your file
        client = new AmazonS3Client(bucketRegion);
        GetObjectRequest request = new GetObjectRequest();
        request.WithBucketName(BUCKET_NAME);//TestBucket
        request.WithKey(S3_KEY);//testuser/AWS_sFTP_Key.pem
        GetObjectResponse response = client.GetObject(request);
        StreamReader reader = new StreamReader(response.ResponseStream);
        String content = reader.ReadToEnd();

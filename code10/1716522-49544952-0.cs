    Stream GivenDocInS3Bucket(string pathToTestDoc)
    {
      var docStream = new FileInfo(pathToTestDoc).OpenRead();
    
      s3ClientMock
        .Setup(x => x.GetObjectAsync(
           It.IsAny<string>(), 
           It.IsAny<string>(), 
           It.IsAny<CancellationToken>()))
        .ReturnsAsync(
           (string bucket, string key, CancellationToken ct) =>
             new GetObjectResponse
             {
               BucketName = bucket,
               Key = key,
               HttpStatusCode = HttpStatusCode.OK,
               ResponseStream = docStream,
             });
    
      return docStream;
    }

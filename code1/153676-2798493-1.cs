    MemoryStream ms = new MemoryStream();
    using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
    {
        byte[] buffer = Encoding.UTF8.GetBytes(content);
        zip.Write(buffer, 0, buffer.Length);
        zip.Flush();
    }
    ms.Position = 0;
    PutObjectRequest request = new PutObjectRequest();
    request.InputStream = ms;
    request.Key = AWSS3PrefixPath + "/" + keyName+ ".htm.gz";
    request.BucketName = AWSS3BuckenName;
    using (AmazonS3 client = Amazon.AWSClientFactory.CreateAmazonS3Client(
                                 AWSAccessKeyID, AWSSecretAccessKeyID))
    using (S3Response putResponse = client.PutObject(request))
    {
        //process response
    }

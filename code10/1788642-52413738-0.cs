    public async Task<Stream> ReadObjectData(MediaFolder key, String fileName)
    {
        try
        {
            using (var client = new AmazonS3Client(accessKey, accessSecret, endpoint))
            {
                var request = new GetObjectRequest
                {
                    BucketName = bucket,
                    Key = key + "/" + fileName
                };
    
                using (var getObjectResponse = await client.GetObjectAsync(request))
                {
                    using (var responseStream = getObjectResponse.ResponseStream)
                    {
                        var stream = new MemoryStream();
                        await responseStream.CopyToAsync(stream);
                        stream.Position = 0;
                        return stream;
                    }
                }
            }
        }
        catch (Exception exception)
        {
            throw new Exception("Read object operation failed.", exception);
        }
    }

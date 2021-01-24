    static async Task ReadStream()
    { 
        try
        {
            GetObjectRequest request = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = keyName
            };
            using (GetObjectResponse response = await client.GetObjectAsync(getObjectRequest))
            using (Stream responseStream = response.ResponseStream)
            using (MemoryStream reader = new MemoryStream(responseStream))
            {
                //your codes
            }
        }
        catch (AmazonS3Exception e)
        {
            //Handle it
        }
        catch (Exception e)
        {
            //Handle it
        }
    }

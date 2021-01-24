    try
    {
        GetObjectRequest getObjectRequest = new GetObjectRequest();
        getObjectRequest.BucketName = Bucketname;
        getObjectRequest.Key = Keyname;
    
        var getObjectResponse = await client.GetObjectAsync(getObjectRequest);
        getObjectResponse.Wait();
        await getObjectResponse.Result.ResponseStream.CopyToAsync(ms);
        var len = ms.Length; 
        return File(ms.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "filename");
    } 

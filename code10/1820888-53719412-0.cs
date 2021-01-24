    public static void DownloadFile()
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls | SecurityProtocolType.Tls;
    
                var client = new AmazonS3Client(keyId, keySecret, bucketRegion);
                ListObjectsRequest request = new ListObjectsRequest();
    
                request.BucketName = "BUCKET_NAME";
                request.Prefix = "/private/TargetFolder";
                request.Delimiter = "/";
                request.MaxKeys = 1000;
    
                ListObjectsResponse response = client.ListObjects(request);
                var x = response.S3Objects;
    
                foreach (var objt in x)
                {
                    GetObjectRequest request1 = new GetObjectRequest();
                    request1.BucketName = "BUCKET_NAME";
                    request1.Key = objt.Key;
    
                    GetObjectResponse Response = client.GetObject(request1);
    
                    using (Stream responseStream = Response.ResponseStream)
                    {
                        Response.WriteResponseStreamToFile(downloadLocation + "\\" + o.Key);
                    }
    
                }
            }

        public static void AddItemToStorage(byte[] byteArray, string itemName)
        {
            MemoryStream itemStream = new MemoryStream(byteArray);
            var config = new AmazonS3Config();
            config.UseHttp = true;
            config.RegionEndpoint = Amazon.RegionEndpoint.EUCentral1;
            var credentials = new Amazon.Runtime.BasicAWSCredentials(
                "AWSUserKey",
                "AWSPassword"
                );
            AmazonS3Client client = new AmazonS3Client(credentials, config);
            TransferUtility tu = new TransferUtility(client);
            itemStream.Seek(0, SeekOrigin.Begin);
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest()
            {
                BucketName = "bucket_name_here" + Guid.NewGuid().ToString(),
                Key = itemName.Replace(" ", "_"),
                InputStream = itemStream,
                CannedACL = S3CannedACL.PublicRead                
            };
            request.UploadProgressEvent += Request_UploadProgressEvent;
            
            tu.UploadAsync(request).Wait();
            var resp = client.GetACL(new GetACLRequest()
            {
                BucketName = request.BucketName,
                Key = request.Key
            });
            
            itemStream.Dispose();
        }

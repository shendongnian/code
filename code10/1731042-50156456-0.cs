            private string UploadAWS(Stream stream, string contentType, string name,string orgfileName,string lable)
        {
            string accessKey = "xxxxx";
            string secretKey = "xxxxxxx";
            using (client = new AmazonS3Client(accessKey, secretKey, Amazon.RegionEndpoint.USEast1))
            {
                return WritingAnObject(stream, contentType, name, orgfileName,lable);
            }
        }
        private string WritingAnObject(Stream stream, string contentType, string name,string orgfileName,string lable)
        {
            string rtn = string.Empty;
            try
            {
                string bucketName = "xxxxxxxx";
                PutObjectRequest putRequest2 = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = name,
                    ContentType = contentType,
                    InputStream = stream
                };
                putRequest2.Metadata.Add("x-amz-meta-title", lable);
                putRequest2.Metadata.Add("x-amz-meta-original-file-name", orgfileName);
                PutObjectResponse response2 = client.PutObject(putRequest2);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                    ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    rtn="Check the provided AWS Credentials.";
                }
                else
                {
                    rtn="Error occurred. Message:"+ amazonS3Exception.Message + " when writing an object";
                }
            }
            return rtn;
        }
  

		private static void ListACLs(BasicAWSCredentials credentials, RegionEndpoint regionEndpoint, string bucketName)
		{
			using (var client = new AmazonS3Client(credentials, regionEndpoint))
			{
				var s3Objects = client.ListObjectsV2(new ListObjectsV2Request
				{
					BucketName = bucketName
				}).S3Objects;
				foreach (var s3Object in s3Objects)
				{
					var getAclRequest = new GetACLRequest
					{
						BucketName = bucketName,
						Key = s3Object.Key
					};
					var grants = client.GetACL(getAclRequest).AccessControlList.Grants;
					foreach (var s3Grant in grants)
					{
						Console.WriteLine(s3Grant.Permission);
					}
				}
			}
		}
 

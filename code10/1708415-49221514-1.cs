		private static void ListACLs(BasicAWSCredentials credentials, RegionEndpoint regionEndpoint, string bucketName, string key)
		{
			using (var client = new AmazonS3Client(credentials, regionEndpoint))
			{
				var getAclRequest = new GetACLRequest
				{
					BucketName = bucketName,
					Key = key
				};
				var grants = client.GetACL(getAclRequest).AccessControlList.Grants;
				foreach (var s3Grant in grants)
				{
					Console.WriteLine(s3Grant.Permission);
				}
			}
		}

	private void putFileWorker(string ID, Stream content)
    {
		try
		{
			//Get bucket name:
			var bucketName = getBucketName(ID)
				.ToLower();
			//get file key
			var fileKey = getFileKey(ID);
			try
			{
				//if the bucket doesn't exist, create it
				if (!Amazon.S3.Util.AmazonS3Util.DoesS3BucketExist(bucketName, s3client))
					s3client.PutBucket(new PutBucketRequest { BucketName = bucketName, BucketRegion = S3Region.EU });
				//
				// ... 
				// 
			}
			catch (Exception e)
			{
				OnPutFileError(this, new ExceptionEventArgs { Exception = e });
			}
		}
		finally
		{
			latch.Signal();
		}
    }

    if (CloudStorageAccount.TryParse(connectionString, out CloudStorageAccount storageAccount))
    {
    	var context = new OperationContext();
    	var options = new BlobRequestOptions();
    	var cloudBlobClient = storageAccount.CreateCloudBlobClient();
    	var cloudBlobContainer = cloudBlobClient.GetContainerReference(blobContainerName);
    	BlobContinuationToken blobContinuationToken = null;
    	do
    	{
    		var results = await cloudBlobContainer.ListBlobsSegmentedAsync(null, true, BlobListingDetails.All,
    			null, blobContinuationToken, options, context);
    		blobContinuationToken = results.ContinuationToken;
    		foreach (var item in results.Results)
    		{
    			//do what you want with each blob
    		}
    	} while (blobContinuationToken != null);
    }

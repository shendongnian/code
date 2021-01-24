    var blobContainerName = "users";
    var storageCredentials = new StorageCredentials(azureStorageAccountName, azureStorageAccountKey);
    var storageAccount = new CloudStorageAccount(storageCredentials, true);
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
    		if(item is CloudBlockBlob blockBlob)
    		{
    			string path = $"{target}{blockBlob.Name}";
    			blockBlob.DownloadToFile(path, FileMode.OpenOrCreate);
    		}
    	}
    } while (blobContinuationToken != null);

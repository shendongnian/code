    CloudStorageAccount storageAccount = CloudStorageAccount.Parse("Storage Account")
    CloudBlobClient sourceBlobClient = storageAccount.CreateCloudBlobClient();
    
    var sourceContainer = sourceBlobClient.GetContainerReference("Container Name");
    var blockBlob = blobContainer.GetBlockBlobReference("Blob Name");
    
    blockBlob.FetchAttributesAsync().Wait();
    //var blobCreatedDate = blockBlob.Properties.Created;
    var propName = "Created"
	Type tModelType = blockBlob.Properties.GetType();
	var propertyInfo = tModelType.GetProperty(propName);
    If  (propertyInfo != null) {
	    var blobCreatedDate = propertyInfo.GetValue(blockBlob.Properties).ToString();
    }

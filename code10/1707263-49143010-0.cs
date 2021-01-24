    var account = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
    var blobClient = account.CreateCloudBlobClient();
    var blobContainer = blobClient.GetContainerReference(destinationContainer);
    blobContainer.CreateIfNotExists();
    var newBlockBlob = blobContainer.GetBlockBlobReference(newFileName);
    newBlockBlob.StartCopy(new Uri(sourceUrl));
    
    // Monitor the copy state
    while (true)
    {
        newBlockBlob.FetchAttributes();
        Console.WriteLine("Copy state: {0}", newBlockBlob.CopyState);
        if (newBlockBlob.CopyState.Status != CopyStatus.Pending)
        {
            break;
        }
 
        Thread.Sleep(waitTime);
    }

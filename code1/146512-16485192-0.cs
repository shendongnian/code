    public static bool BlobExistsOnCloud(CloudBlobClient client, 
        string containerName, string key)
    {
         return client.GetContainerReference(containerName)
                      .GetBlockBlobReference(key)
                      .Exists();  
    }

    public async Task SaveBlob(string containerName, string key, byte[] blobToSave)
    {
      var blobClient = _storageAccount.CreateCloudBlobClient();
      var blobContainer = blobClient.GetContainerReference(containerName);
      await blobContainer.CreateIfNotExistsAsync();
      var blockBlob = container.GetBlockBlobReference(key);
      await blockBlob.UploadFromByteArrayAsync(blobToSave, 0, blobToSave.Length);
    }

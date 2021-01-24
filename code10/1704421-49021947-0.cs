    public string GetAzureStoreImage(string fileName, string containerName)
    {
            string imageUrl = string.Empty;
            // Connect to cloud storage account
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("YourStoredConnectionString"));
            // Connect blob client
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            // Connect to container
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            // Get reference for current file
            CloudBlockBlob blob = container.GetBlockBlobReference(fileName);
            if (blob.Exists())
            {
                // Create access token for file share
                var sasToken = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
                {
                    Permissions = SharedAccessBlobPermissions.Read,
                    SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(10),
                }, new SharedAccessBlobHeaders()
                {
                    ContentDisposition = "attachment; filename=" + fileName
                });
                // Collect url and download file
                imageUrl = string.Format("{0}{1}", blob.Uri, sasToken);
            }
            return imageUrl;
    }

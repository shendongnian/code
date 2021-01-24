        public CloudBlobContainer GetCloudBlobContainer(string strBlobContainerName)
        {
            CloudStorageAccount storageAccount = 
    CloudStorageAccount.Parse(Convert.ToString(ConfigurationManager.AppSettings["BlobConnectionString"]));
                        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                        CloudBlobContainer blobContainer = blobClient.GetContainerReference(strBlobContainerName);
            
                        blobContainer.CreateIfNotExists();
                        blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                        return blobContainer;
         }

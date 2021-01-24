            public ActionResult DownloadFile()
            {
                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("your_account", "your_key"),true);
                CloudBlobClient client = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer blobContainer = client.GetContainerReference("t11");
                CloudBlob blob = blobContainer.GetBlockBlobReference("ss22.pdf");
    
                blob.DownloadToStream(Response.OutputStream);
                
                return new EmptyResult();
            }

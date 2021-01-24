            public ActionResult DownloadFile()
            {
                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("your_account", "your_key"), true);
                CloudBlobClient client = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer blobContainer = client.GetContainerReference("t11");
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference("ss22.pdf");
               
                blob.FetchAttributes();
    
                long fileByteLength = blob.Properties.Length;
                byte[] fileContent = new byte[fileByteLength];
                for (int i=0;i<fileByteLength;i++)
                {
                    fileContent[i] = 0x20;
                }
    
                blob.DownloadToByteArray(fileContent,0);
    
                Response.BinaryWrite(fileContent);
    
                return new EmptyResult();
            }

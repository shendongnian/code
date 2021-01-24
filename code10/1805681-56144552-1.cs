     public async System.Threading.Tasks.Task<ActionResult> DownloadFile1()
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.ConnectionStrings["azureconnectionstring"].ConnectionString);
               
                CloudBlobClient client = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer blobContainer = client.GetContainerReference("my-blob-storage");
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference("designing-and-building-interactive-ebook.pdf");
    
                Byte[] dataBytes1;
    
                blob.FetchAttributes();
    
                using (StreamReader blobfilestream = new StreamReader(blob.OpenRead()))
                {
                    dataBytes1 = blobfilestream.CurrentEncoding.GetBytes(blobfilestream.ReadToEnd());
                }
                Byte[] value = BitConverter.GetBytes(dataBytes1.Length - 1);
              
                await blob.DownloadToStreamAsync(Response.OutputStream);
                return new EmptyResult();
      
            }

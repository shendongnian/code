    public static class Function1
        {
            [FunctionName("Function1")]
            public static void Run([BlobTrigger("helloworld/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob, string name, TraceWriter log)
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
       "storage account connection string");
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("helloworld");
                CloudAppendBlob blob = container.GetAppendBlobReference("log2.txt");
                using (var fileStream = System.IO.File.OpenRead(@"D:\log.txt"))
                {
                    blob.UploadFromStreamAsync(fileStream);
                }
                log.Info($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
            }
    
    }

    [FunctionName("UniquePermissionsReporting")]                                                                     
    public static void Run(
    [ServiceBusTrigger("spo-governance-report-permissions", AccessRights.Manage, Connection = "UniquePermisionsQueueConnStr")]string myQueueItem,
    [Blob("unique-permission-reports", FileAccess.Read, Connection ="BlobStorageConnStr")] CloudBlobContainer blobContainer,
    TraceWriter log)
    {
            string blobName = "test.csv";
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference($"{blobName}");
            // ensure the csv content type if necessary
            blob.Properties.ContentType = "text/csv";
            // use Upload* method according to your need
            blob.UploadText("content");
    }

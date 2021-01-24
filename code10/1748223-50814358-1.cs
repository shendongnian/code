        /// <summary>
        /// Download File From Blob
        /// </summary>
        /// <param name="fileName">For example: image.PNG</param>
        /// <param name="containerName">container name of blob</param>
        /// <param name="localFilePath">For example: @"C:\Test\BlobTest.PNG"</param>
        private void DownloadFileFromBlob(string fileName, string containerName, string localFilePath)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse("Your connection string");
            CloudBlobClient blobClient = account.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            CloudBlob blob = container.GetBlobReference(fileName);
            using (var fileStream = System.IO.File.OpenWrite(localFilePath))
            {
                blob.DownloadToStream(fileStream);
            }
        }

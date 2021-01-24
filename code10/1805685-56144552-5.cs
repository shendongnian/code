         public async System.Threading.Tasks.Task<ActionResult> DownloadFile()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            ConfigurationManager.ConnectionStrings["azureconnectionstring"].ConnectionString);
            CloudBlobClient client = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = client.GetContainerReference("my-blob-storage");
	    CloudBlockBlob blob = blobContainer.GetBlockBlobReference("filename.pdf");
            var exists = blob.Exists(); // to verify if file exist
            blob.FetchAttributes();
            byte[] dataBytes1;
            using (StreamReader blobfilestream = new StreamReader(blob.OpenRead()))
            {
                dataBytes1 = blobfilestream.CurrentEncoding.GetBytes(blobfilestream.ReadToEnd());
                await blob.DownloadToStreamAsync(Response.OutputStream);
            }
            Byte[] value = BitConverter.GetBytes(dataBytes1.Length - 1);
            string mimeType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "inline; filename=" + "filename.pdf");
            return File(value, mimeType);
}

        private async static Task<string> CreateBlob(string name, byte[] data, TraceWriter log, CloudBlobContainer container)
        {
            CloudBlockBlob blob = container.GetBlockBlobReference(name);
            blob.Properties.ContentType = "image/png";
            using (Stream stream = new MemoryStream(data))
            {
                await blob.UploadFromStreamAsync(stream);
            }
            return blob.Uri.AbsoluteUri;
        }

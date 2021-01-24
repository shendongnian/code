    // ... Get the Azure Blob file in to a Stream called myBlob
    // As mentioned above the Azure function does this for you:
    // public static void Run([BlobTrigger("containerName/{name}", Connection = "BlobConnection")]Stream myBlob, string name, ILogger log)
    using (WebClient client = new WebClient())
    {
        using (MemoryStream ms = new MemoryStream())
        {
            myBlob.CopyTo(ms);
            client.UploadData("ftp://ftpserver", ms.ToArray());
        }
    }

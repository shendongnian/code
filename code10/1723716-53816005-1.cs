    // ... Get the Azure Blob file in to a Stream called myBlob
    // As mentioned above the Azure function does this for you:
    // public static void Run([BlobTrigger("containerName/{name}", Connection = "BlobConnection")]Stream myBlob, string name, ILogger log)
    public void UploadStreamToFtp(Stream file, string targetFilePath)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // As memory stream already handles ToArray() copy the Stream to the MemoryStream
                file.CopyTo(ms);
                using (WebClient client = new WebClient())
                {
                    // Use login credentails if required
                    client.Credentials = new NetworkCredential("username", "password");
                    // Upload the stream as Data with the STOR method call
                    // targetFilePath is a fully qualified filepath on the FTP, e.g. ftp://targetserver/directory/filename.ext
                    client.UploadData(targetFilePath, WebRequestMethods.Ftp.UploadFile, ms.ToArray());
                }
            }
        }

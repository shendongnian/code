    public MemoryStream GetFile(string strPath)
            {
                try
                {
                    var filename = Path.GetFileName(strPath);
                    string account = ConfigurationManager.AppSettings["accountName"];
                    string key = ConfigurationManager.AppSettings["accountKey"];
                    string containerName = "test";
                    string connectionString =$"DefaultEndpointsProtocol=https;AccountName={account};AccountKey={key}";
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
                    var blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobClient.GetContainerReference(containerName);
                    CloudBlockBlob blob = container.GetBlockBlobReference(filename);
                    MemoryStream memory = new MemoryStream();
                    blob.DownloadToStream(memory);
                    var zipArchive = new ZipArchive(memory, ZipArchiveMode.Read, true);
                    var entry = zipArchive.Entries.First();
                    if (entry != null)
                    {
                        var stream = entry.Open();
                        memory = new MemoryStream();
                        stream.CopyTo(memory);
                        memory.Position = 0;
                        return memory;
                    }
    
                    return null;
                }
                catch (Exception)
                {
                    // download failed
                    // handle exception
                    throw;
                }
            }

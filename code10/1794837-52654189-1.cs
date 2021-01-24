    var containerName = "pgpkeys";
                string storageConnection = CloudConfigurationManager.GetSetting("StorageConnnection");
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(storageConnection);
                CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = blobClient.GetContainerReference(containerName);
                CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference("keyPublic.txt");
                Stream inputStream = new MemoryStream();           
                blockBlob.DownloadToStream(inputStream);
                inputStream.Position = 0;
             
            inputStream = PgpUtilities.GetDecoderStream(inputStream);
            PgpPublicKeyRingBundle pgpPub = new PgpPublicKeyRingBundle(inputStream);
      
            foreach (PgpPublicKeyRing kRing in pgpPub.GetKeyRings())
            {
                foreach (PgpPublicKey k in kRing.GetPublicKeys())
                {
                    Console.WriteLine("Obtained key from BLOB");
                    if (k.IsEncryptionKey)
                        return k;
                    Console.WriteLine("Obtained key from BLOB");
                }
            }
            throw new ArgumentException("Can't find encryption key in key ring.");

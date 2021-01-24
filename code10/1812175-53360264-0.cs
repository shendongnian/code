                    foreach (String blobName in blobNames)
                    {
                        CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
                        bool isDeleted = blockBlob.DeleteIfExists();
                    }
 

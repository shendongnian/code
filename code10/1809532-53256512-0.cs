    public static void RenameBlob(string containerName, string destContainer,string blobName,string newblobname)
    {
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
        CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer imgcontainer = cloudBlobClient.GetContainerReference(containerName);
        string[] name = blobName.Split('.');
        //rename blob
        string newBlobName = name[0] + "_"+DateTime.Now.ToString("MM")+"_"+DateTime.Now.ToString("yyyy") + "." + name[1];
        CloudBlobContainer oldcontainer = cloudBlobClient.GetContainerReference(destContainer);
        if (!oldcontainer.Exists())
        {
            throw new Exception("Destination container does not exist.");
        }
        CloudBlockBlob blobCopy = oldcontainer.GetBlockBlobReference(newBlobName);
        if (!blobCopy.Exists())
        {
            CloudBlockBlob blob = imgcontainer.GetBlockBlobReference(blobName);
            if (blob.Exists())
            {
                //move blob to oldcontainer
                blobCopy.StartCopy(blob);
                blob.Delete();
            }
        }
        //upload blob to imagecontainer
        CloudBlockBlob cloudblobnew = imgcontainer.GetBlockBlobReference(newblobname);
        cloudblobnew.UploadFromFileAsync(newfile);
    }

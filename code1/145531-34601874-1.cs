    CloudBlobContainer container = blobClient.GetContainerReference("photos");
    
    //1. grab a folder from the container
    CloudBlobDirectory folder = container.GetDirectoryReference("directoryName");
    //2. Loop over container and grab folders.
    foreach (IListBlobItem item in container.ListBlobs(null, false))
    {
        if (item.GetType() == typeof(CloudBlobDirectory))
        {
            // we know this is a sub directory now
            CloudBlobDirectory subFolder = (CloudBlobDirectory)item;
    
            Console.WriteLine("Directory: {0}", subFolder.Uri);
        }
    }

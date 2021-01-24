    // I left fully qualified names of the types to make example clear.
    
    var connectionString = "Connection string from `Azure Portal > Storage account > Access Keys`";
    var sourceContainerName = "<source>";
    var destinationContainerName = "<destination>";
    var storageAccount = Microsoft.Azure.Storage.CloudStorageAccount.Parse(connectionString);
    var client = storageAccount.CreateCloudBlobClient();
    var sourceContainer = client.GetContainerReference(sourceContainerName);
    var destinationContainer = client.GetContainerReference(destinationContainerName);
    // Create destination container if needed
    await destinationContainer.CreateIfNotExistsAsync();
    var sourceBlobDir = sourceContainer.GetDirectoryReference("");
    var destBlobDir = destinationContainer.GetDirectoryReference("");
    // Use UploadOptions to set ContentType of destination CloudBlob
    var options = new Microsoft.Azure.Storage.DataMovement.CopyDirectoryOptions
    {
        Recursive = true,
    };
    var context = new Microsoft.Azure.Storage.DataMovement.DirectoryTransferContext();
    // Perform the copy
    var transferStatus = await Microsoft.Azure.Storage.DataMovement.TransferManager
        .CopyDirectoryAsync(sourceBlobDir, destBlobDir, true, options, context);

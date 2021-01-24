    var blobClient = storageAccount.CreateCloudBlobClient();
    var blobContainers = new List<CloudBlobContainer>();
    BlobContinuationToken blobContinuationToken = null;
    do
    {
        var containerSegment = await blobClient.ListContainersSegmentedAsync(blobContinuationToken);
        blobContainers.AddRange(containerSegment.Results);
        blobContinuationToken = containerSegment.ContinuationToken;
    } while (blobContinuationToken != null);

    public async Task RetrieveBlobsModifiedTodayAsync()
    {
        var container = _blobClient.GetContainerReference(_storageAccount.ContainerName);
    
        BlobContinuationToken blobContinuationToken = null;
        do
        {
            var results = await container.ListBlobsSegmentedAsync(null, blobContinuationToken);
    
            var blobs = results.Results.OfType<CloudBlockBlob>()
                .Where(b => b.Properties.LastModified != null && b.Properties.LastModified.Value.Date == DateTime.Today);
    
            blobContinuationToken = results.ContinuationToken;
            foreach (var item in blobs)
            {
                Console.WriteLine(item.Uri);
            }
        } while (blobContinuationToken != null); // Loop while the continuation token is not null. 
    }

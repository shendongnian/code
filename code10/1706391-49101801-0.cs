    var container = _client.GetContainerReference(_containerName);
    var bs = container.ListBlobs(null, true, BlobListingDetails.All).Cast<CloudBlockBlob>();
    foreach (var item in bs)
    {
        var blob = container.GetBlockBlobReference(item.Name);
        blob.Properties.ContentDisposition = "attachment; filename=" + Path.GetFileName(item.Name);
        blob.SetProperties();
    }

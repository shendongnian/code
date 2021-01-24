    List<Task> tasks = new List<Task>();
    foreach (string blobName in blobNames)
    {
        CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
        tasks.Add(blockBlob.DownloadToFileAsync(blobName, FileMode.Create));
    }
    Task.WaitAll(tasks.ToArray());

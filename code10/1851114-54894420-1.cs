    foreach (var link in SharedVars.DownloadQueue)
    {
        var task = DownloadFile(extraPathPerLink, link, totalLen);
        downloadQueueLinksTasks.Add(task);
        if (downloadQueueLinksTasks.Count == batch)
        {
            // Wait for any Task to complete, then remove it from
            // the list of pending tasks.
            var completedTask = await Task.WhenAny(downloadQueueLinksTasks);
            downloadQueueLinksTasks.Remove(completedTask);
        }
    }
    // Wait for all of the remaining Tasks to complete
    await Task.WhenAll(downloadQueueLinksTasks);

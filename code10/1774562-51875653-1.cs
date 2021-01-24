	Action<string, DownloadProgressChangedEventArgs> onDownloadProgress = (url, e) => 
    { 
        /* your logic displaying progress... */ 
    };
	var downloadTasks = urls
		.Where(url => !FileExistsOrNot(Path.Combine(localPath, url.fileName)))
		.Select(async url =>
		{
			using (var client = new WebClient())
			{
				client.DownloadProgressChanged += (s, e) => onDownloadProgress(url.fileName, e);
				try { await client.DownloadFileTaskAsync(new Uri(url.downloadUrl), Path.Combine(localPath, url.fileName)); }
				catch (Exception ex) { /* handle download error: log exception, etc */ }				
			}
		});    
  
    Task.WaitAll(downloadTasks.ToArray()); // or Task.WhenAll(...) if you want it non-blocking

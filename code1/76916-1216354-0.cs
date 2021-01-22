	private void BeginDownload(
		string uriString,
		string localFile,
		Action<string, DownloadProgressChangedEventArgs> onProgress,
		Action<string, AsyncCompletedEventArgs> onComplete)
	{
		WebClient webClient = new WebClient();
		webClient.DownloadProgressChanged +=
			(object sender, DownloadProgressChangedEventArgs e) =>
				onProgress(localFile, e);
		webClient.DownloadFileCompleted +=
			(object sender, AsyncCompletedEventArgs e) =>
				onComplete(localFile, e);
		webClient.DownloadFileAsync(new Uri(uriString), localFile);
	}

	Action<string, DownloadProgressChangedEventArgs> onProgress =
		(string localFile, DownloadProgressChangedEventArgs e) =>
		{
			Console.WriteLine("{0}: {1}/{2} bytes received ({3}%)",
				localFile, e.BytesReceived,
				e.TotalBytesToReceive, e.ProgressPercentage);
		};
	Action<string, AsyncCompletedEventArgs> onComplete =
		(string localFile, AsyncCompletedEventArgs e) =>
		{
			Console.WriteLine("{0}: {1}", localFile,
				e.Error != null ? e.Error.Message : "Completed");
		};
	downloader.BeginDownload(
		@"http://url/to/file",
		@"/local/path/to/file",
		onProgress, onComplete);

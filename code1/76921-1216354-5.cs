	private void BeginDownload(string uriString, string localFile)
	{
		WebClient webClient = new WebClient();
		webClient.DownloadProgressChanged +=
			(object sender, DownloadProgressChangedEventArgs e) =>
				Console.WriteLine("{0}: {1}/{2} bytes received ({3}%)",
					localFile, e.BytesReceived,
					e.TotalBytesToReceive, e.ProgressPercentage);
		webClient.DownloadFileCompleted +=
			(object sender, AsyncCompletedEventArgs e) =>
				Console.WriteLine("{0}: {1}", localFile,
					e.Error != null ? e.Error.Message : "Completed");
		webClient.DownloadFileAsync(new Uri(uriString), localFile);
	}

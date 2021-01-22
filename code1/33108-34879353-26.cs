    client.DownloadProgressChanged += (o, e) =>
    {
        Console.WriteLine($"Download status: {e.ProgressPercentage}%.");
        // updating the UI
		Dispatcher.Invoke(() => {
			progressBar.Value = e.ProgressPercentage;
		});
    };
    client.DownloadDataCompleted += (o, e) => 
    {
        Console.WriteLine("Download finished!");
    };

	string originalLblContent = (lblProgress.Content as string) ?? "";
	bool taskStarted = false;
	
	var progressThread = new Thread((ThreadStart)delegate
	{
		// this code will run in the background thread
		string dots = "";
		while(!taskStarted || !task.IsCompleted) {
			if(dots.Length < 3) {
				dots += ".";
			} else {
				dots = "";
			}
			// because we are in the background thread, we need to invoke the UI thread
			// we can invoke it because your task is running asynchronously and NOT blocking the UI thread
			Dispatcher.Invoke(() =>
			{
				lblProgress.Content = originalLblContent + dots;
			});
			Thread.Sleep(1000);
		}
	});
	progressThread.Start();
	taskStarted = true;
	await task;
	
	// the task is now finished, and the progressThread will also be after 1 second ...

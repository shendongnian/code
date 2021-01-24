	private Task DisplayTask;
	private CancellationTokenSource CancelSource;
	private void Image_MouseDown(object sender, MouseButtonEventArgs e)
	{
		// cancel any existing task and wait for it to finish
		if (this.CancelSource != null)
		{
			this.CancelSource.Cancel();
			try
			{
				this.DisplayTask.Wait(this.CancelSource.Token);
			}
			catch (OperationCanceledException)
			{
				// catches the expected exception here
			}
				
		}
		// start a new task
		this.CancelSource = new CancellationTokenSource();
		this.DisplayTask = Task.Run(DisplayImages);
	}
	private async Task DisplayImages()
	{
		seals.ImageSource = new BitmapImage(new Uri(@"C:\Users\billw\Documents\Visual Studio 2015\Projects\Images\seal_2 transparent.png", UriKind.Absolute));
		await Task.Delay(TimeSpan.FromSeconds(2), this.CancelSource.Token);
		seals.ImageSource = new BitmapImage(new Uri(@"C:\Users\billw\Documents\Visual Studio 2015\Projects\Images\seal_3 transparent.png", UriKind.Absolute));
		await Task.Delay(TimeSpan.FromSeconds(2), this.CancelSource.Token);
		... etc ...
	}

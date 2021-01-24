	private CancellationTokenSource tokenSource;
	
	public async void Search(string name)
	{
		this.tokenSource?.Cancel();
		this.tokenSource = new CancellationTokenSource();
		var token = this.tokenSource.Token;
		this.IsBusy = true;
		try
		{
		    // await for the result from your async method (non void)
			var result = await this.GetStudentResults(name, token);
			
			// If it was cancelled by re-entry, just return
			if (token.IsCancellationRequested)
			{
				return;
			}
			// If not cancelled then stop busy state
			this.IsBusy = false;
			Console.WriteLine($"{name} {result}");
		}
		catch (TaskCanceledException ex)
		{
			// Canceling the task will throw TaskCanceledException so handle it
			Trace.WriteLine(ex.Message);
		}
	}

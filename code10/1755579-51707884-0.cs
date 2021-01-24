	private async Task GetStop(CancellationToken token)
	{ 
		await Task.Run(async () =>
		{
            // I think you don't need to throw here
			token.ThrowIfCancellationRequested();
            // this will throw an Exception when cancelled
			await Task.Delay(TimeSpan.FromSeconds(60), token); 
            // again, I think you don't need to throw here
			token.ThrowIfCancellationRequested();
			if (!token.IsCancellationRequested)
			{
				sendMessage((byte)ACMessage.AC_ESCAPE); 
			}
		}, token);
	}
	public async void Play()
	{         
			sendMessage((byte)ACMessage.AC_START_RACE); 
            // at some scenarios this may be null
			_cts.Cancel();
			if (_cts != null)
			{
				_cts.Dispose();
				_cts = null;
			}
			_cts = new CancellationTokenSource(); 
			await GetStop(_cts.Token);
	   }
	public void Quit()
	{
			_cts.Cancel();
			if (_cts != null)
			{
				_cts.Dispose();
				_cts = null;
			}
	}

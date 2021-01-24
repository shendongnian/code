    public async void LoadFrom()
	{
		var uri = new Uri("https://api.coinmarketcap.com/v2/ticker/?convert=usd&sort=price");
		try
		{
			HttpClient myClient = new HttpClient();
			var response = await myClient.GetStringAsync(uri);
			Console.WriteLine(response);
		}
		catch (TimeoutException ex)
		{
			// Check ex.CancellationToken.IsCancellationRequested here.
			// If false, it's pretty safe to assume it was a timeout.
		}
		catch (TaskCanceledException ex)
		{
			// Check ex.CancellationToken.IsCancellationRequested here.
			// If false, it's pretty safe to assume it was a timeout.
		}
		catch (Exception e)
		{
		}
	}

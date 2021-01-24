	using (var cancellationTokenSource = new CancellationTokenSource())
	{
		var result = await DialogAsync.Show(this, "StackOverflow", "Does it rock?", cancellationTokenSource);
		if (!cancellationTokenSource.Token.IsCancellationRequested)
		{
			Log.Debug("SO", $"Dialog result: {result}");
		}
		else
		{
			Log.Debug("SO", $"Dialog cancelled; backbutton, click outside dialog, system-initiated, .... ");
		}
	}

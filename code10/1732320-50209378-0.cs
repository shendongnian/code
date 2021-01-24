	private static CancellationTokenSource _cancellationTokenSource;
	private void Btn_Click(object sender, EventArgs e)
	{
		if(previousPress)
		{
			_cancellationTokenSource.Cancel();
		}
		_cancellationTokenSource = new CancellationTokenSource();
		TaskMethod(_cancellationTokenSource.Token);
	}
	private async void TaskMethod(CancellationToken cancellationToken)
	{
		await Task.Delay(1000, cancellationToken);
		MessageBox.Show("Hello World!");
	}

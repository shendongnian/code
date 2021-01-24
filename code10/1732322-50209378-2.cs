	private static CancellationTokenSource _cancellationTokenSource;
	private void Btn_Click(object sender, EventArgs e)
	{
		if(previousPress)
		{
			_cancellationTokenSource.Cancel();
		}
		_cancellationTokenSource = new CancellationTokenSource();
		TaskMethodAsync(_cancellationTokenSource.Token);
	}
	private async Task TaskMethodAsync(CancellationToken cancellationToken)
	{
		await Task.Delay(1000, cancellationToken);
		MessageBox.Show("Hello World!");
	}

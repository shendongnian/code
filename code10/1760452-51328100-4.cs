	public void UPDATEME(string MSG, bool finish = false)
	{
		if (this.InvokeRequired)
		{
			this.Invoke((MethodInvoker)delegate
			{
				this.updater(MSG, finish);
			});
		}
		else
		{
			this.updater(MSG, finish);
		}
	}
	private void updater(string MSG, bool finish = false) // NOT thread safe, thus the private (don't call directly)
	{
		this.label1.Text = MSG;
		if (finish) { this.Close(); }
	}

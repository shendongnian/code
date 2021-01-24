	public void UPDATEME(string MSG, bool finish = false)
	{
		if (this.InvokeRequired)
		{
			this.Invoke(new MethodInvoker(() => this.UPDATEME(MSG, finish)));
		}
		else
		{
			this.label1.Text = MSG;
			if (finish) { this.Close(); }
		}
	}

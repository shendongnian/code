	public void UPDATEME(string MSG, bool finish = false)
	{
		if (this.InvokeRequired)
		{
			this.Invoke(new Action(() =>
			{
				this.label1.Text = MSG;
				if (finish) { this.Close(); }
			}));
		}
		else
		{
			this.label1.Text = MSG;
			if (finish) { this.Close(); }
		}
	}
	

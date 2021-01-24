	public void UPDATEME(string MSG, bool finish = false)
	{
		this.Invoke(new Action(() =>
		{
			this.label1.Text = MSG;
			if (finish) { this.Close(); }
		}));
	}
	

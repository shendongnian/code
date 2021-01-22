	private void ofdAttachment_FileOk(object sender, CancelEventArgs e)
	{
		Action attach = _b<>_1( attach );
	
		System.Threading.ThreadPool.QueueUserWorkItem((o) => attach());
	}
	
	private Action _b<>_1( Action attach )
	{
		if (this.InvokeRequired)
		{
			// but it has compilation here
			// "Use of unassigned local variable 'attach'"
			this.Invoke(new Action(attach)); 
		}
		else
		{
			// attaching routine here
		}
	}

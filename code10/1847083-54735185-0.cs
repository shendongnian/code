	private void AddMessage(string message)
	{
		if (this.ListBox_Messages.InvokeRequired)
		{
			this.ListBox_Messages.Invoke((MethodInvoker)delegate {
				this.ListBox_Messages.Items.Add(message);
			});
		}
		else
		{
			this.ListBox_Messages.Items.Add(message);
		}          
	}
